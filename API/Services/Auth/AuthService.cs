namespace API.Services.Auth;

using Dapper;
using API.Models.Auth;
using Models.Data;
using Token;
using Microsoft.Data.SqlClient;

public class AuthService(string connectionString, ITokenService tokenService)
    : IAuthService
{
    private readonly string _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    private readonly ITokenService _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));

    public async Task<TokenPair?> LoginAsync(LoginRequest request)
    {
        await using SqlConnection conn = new(_connectionString);
        await conn.OpenAsync();

        const string sql = "SELECT [Id], [Email], [Username], [PasswordHash], [CreatedAt] FROM [dbo].[Users] WHERE [Username] = @Username";
        User? user = await conn.QueryFirstOrDefaultAsync<User>(
            sql,
            new { request.Email }
        );

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        await conn.ExecuteAsync(
            "DELETE FROM [dbo].[RefreshTokens] WHERE [UserId] = @UserId AND [ExpiresAt] < @Now;",
            new { Now = DateTime.UtcNow, UserId = user.Id });
        
        return await _tokenService.IssueTokens(user);
    }

    public async Task<TokenPair?> RegisterAsync(RegisterRequest request)
    {
        await using SqlConnection con = new(_connectionString);

        int exists = await con.ExecuteScalarAsync<int>(
            "SELECT COUNT(1) FROM Users WHERE Email = @Email",
            new { request.Email }
        );

        if (exists > 0)
            return null;

        if (request.Password != request.ConfirmPassword)
            throw new ArgumentException("Passwords do not match.");

        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Username, Email, and Password are required.");

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        int id = await con.ExecuteScalarAsync<int>("""
           INSERT INTO [dbo].[Users] (Username, Email, PasswordHash, CreatedAt)
           OUTPUT INSERTED.Id
           VALUES (@Username, @Email, @PasswordHash, @CreatedAt);
        """, new { request.Email, request.Username, PasswordHash = passwordHash, CreatedAt = DateTime.UtcNow });

        return await _tokenService.IssueTokens(new User(id, request.Username, request.Email, passwordHash, DateTime.UtcNow));
    }

    public async Task<bool> UpdatePasswordAsync(UpdatePasswordRequest request, int userId)
    {
        await using SqlConnection conn = new(_connectionString);
        
        User? user = await conn.QueryFirstOrDefaultAsync<User>(
            "SELECT [Id], [Username], [Email], [PasswordHash], [CreatedAt] FROM [dbo].[Users] WHERE [Id] = @UserId",
            new { UserId = userId }
        );
        
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.OldPassword, user.PasswordHash))
            return false;
        
        string newHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await conn.ExecuteAsync(
            "UPDATE [dbo].[Users] SET [PasswordHash] = @NewPassword WHERE [Id] = @UserId",
            new { NewPassword = newHash, UserId = user.Id }
        );
        
        await conn.ExecuteAsync(
            "DELETE FROM [dbo].[RefreshTokens] WHERE [UserId] = @UserId",
            new { UserId = user.Id }
        );

        return true;
    }

    public async Task<bool> LogoutAsync(int userId, string refreshToken)
    {
        await using SqlConnection conn = new(_connectionString);

        string hashedToken = TokenService.Hash(refreshToken); // use same hashing as when issuing

        int rows = await conn.ExecuteAsync(
            "DELETE FROM RefreshTokens WHERE UserId = @UserId AND TokenHash = @TokenHash",
            new { UserId = userId, TokenHash = hashedToken });

        if (rows > 0)
            return true;
        
        await conn.ExecuteAsync(
            "DELETE FROM RefreshTokens WHERE UserId = @UserId",
            new { UserId = userId, Now = DateTime.UtcNow });
            
        return false;
    }
}