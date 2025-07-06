namespace API.Services.Auth;

using API.Models.Auth;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginRequest request);
    Task<AuthResult> RegisterAsync(RegisterRequest request);
    Task<AuthResult> RefreshTokenAsync(string token);
    Task LogoutAsync(string token);
    Task<bool> ValidateTokenAsync(string token);
}