namespace API.Models.Auth;

public record LoginRequest(string? Email, string? Password);
public record RegisterRequest(string? Email, string? Username, string? Password, string? ConfirmPassword);
public record UpdatePasswordRequest(string OldPassword, string NewPassword);
public record TokenPair(string AccessToken, string RefreshToken, bool IsAdmin);