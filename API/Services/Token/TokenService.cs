using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Token;

using System.Security.Cryptography;
using Dapper;
using Microsoft.Data.SqlClient;
using Models.Auth;
using Models.Data;

public class TokenService(string secretKey, string connectionString) : ITokenService
{
    private readonly string _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));

    public string GenerateToken(User user)
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_secretKey));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512);

        Claim[] claims =
        [
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
            new Claim("username", user.Username),
        ];

        JwtSecurityToken token = new(
            issuer: "Luna",
            audience: "Luna",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException("Token validation is not implemented yet.");
    }

    public async Task<TokenPair> IssueTokens(User user)
    {
        string token = GenerateToken(user);
        
        (string refreshToken, string rtHash, DateTime rtExp) = GenerateRefreshToken();
        
        await using SqlConnection conn = new(connectionString);
        await conn.OpenAsync();
        
        await conn.ExecuteAsync(
            """
            INSERT INTO [dbo].[RefreshTokens] (UserId, TokenHash, ExpiresAt, CreatedAt)
            VALUES (@UserId, @TokenHash, @ExpiresAt, @CreatedAt);
            """,
            new
            {
                UserId = user.Id,
                TokenHash = rtHash,
                ExpiresAt = rtExp,
                CreatedAt = DateTime.UtcNow
            }
        );
        
        return new TokenPair(token, refreshToken);
    }

    public async Task<TokenPair?> RefreshTokensAsync(string refreshToken)
    {
        string hash = Hash(refreshToken);
        await using SqlConnection conn = new(connectionString);
        (int UserId, DateTime ExpiresAt) token = 
            await conn.QuerySingleOrDefaultAsync<(int UserId, DateTime ExpiresAt)>(
            """
            SELECT UserId, ExpiresAt
            FROM RefreshTokens
            WHERE TokenHash = @Hash
            """,
            new { Hash = hash }
        );
        
        if (token == default || token.ExpiresAt < DateTime.UtcNow)
            return null;

        User user = await conn.QuerySingleAsync<User>(
            """
            SELECT Id, Username, Email, PasswordHash, CreatedAt
            FROM Users
            WHERE Id = @UserId
            """,
            new { UserId = token.UserId }
        );
        
        await conn.ExecuteAsync(
            """
            DELETE FROM RefreshTokens
            WHERE UserId = @UserId AND ExpiresAt < @Now;
            """,
            new { UserId = user.Id, Now = DateTime.UtcNow }
        );
        
        await conn.ExecuteAsync(
            """
            DELETE FROM RefreshTokens
            WHERE TokenHash = @Hash;
            """,
            new { Hash = hash }
        );
        
        return await IssueTokens(user);
    }

    private static (string, string, DateTime) GenerateRefreshToken(int days = 30)
    {
        byte[] bytes = RandomNumberGenerator.GetBytes(64);
        string token = Convert.ToBase64String(bytes);

        return (token, Hash(token), DateTime.UtcNow.AddDays(days));
    }

    public static string Hash(string token) =>
        Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
}