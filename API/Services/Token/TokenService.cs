using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Models.Data;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Token;

public class TokenService : ITokenService
{
    private readonly string _secretKey;

    public TokenService(string secretKey)
    {
        _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
    }

    public string GenerateToken(User user)
    {
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_secretKey));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512);

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
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException("Token validation is not implemented yet.");
    }
}