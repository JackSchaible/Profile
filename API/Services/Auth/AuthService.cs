namespace API.Services.Auth;

using Dapper;
using API.Models.Auth;
using API.Services.Token;
using API.Models.Data;
using Microsoft.Data.SqlClient;

public class AuthService
    : IAuthService
{
    private readonly string _connectionString;
    private readonly ITokenService _tokenService;

    public AuthService(string connectionString, ITokenService tokenService)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    public async Task<string?> LoginAsync(LoginRequest request)
    {
        using var conn = new SqlConnection(_connectionString);
        await conn.OpenAsync();

        string sql = "SELECT [Id], [Email], [Username], [PasswordHash], [CreatedAt] FROM [dbo].[Users] WHERE [Username] = @Username";
        User? user = await conn.QueryFirstOrDefaultAsync<User>(
            sql,
            new { request.Email }
        );

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        return _tokenService.GenerateToken(user);
    }

    public Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        // Implement registration logic here
        throw new NotImplementedException();
    }

    public Task<AuthResult> RefreshTokenAsync(string token)
    {
        // Implement token refresh logic here
        throw new NotImplementedException();
    }

    public Task LogoutAsync(string token)
    {
        // Implement logout logic here
        throw new NotImplementedException();
    }

    public Task<bool> ValidateTokenAsync(string token)
    {
        // Implement token validation logic here
        throw new NotImplementedException();
    }
}