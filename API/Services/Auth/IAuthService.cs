namespace API.Services.Auth;

using System.Security.Claims;
using API.Models.Auth;

public interface IAuthService
{
    Task<TokenPair?> LoginAsync(LoginRequest request);
    Task<TokenPair?> RegisterAsync(RegisterRequest request);
    Task<bool> UpdatePasswordAsync(UpdatePasswordRequest request, int userId);
    Task<bool> LogoutAsync(int userId, string refreshToken);
    bool IsAdmin(ClaimsPrincipal principal);
    bool IsAdmin(string email);
}