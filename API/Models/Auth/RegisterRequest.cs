namespace API.Models.Auth;

public record RegisterRequest
(
    string? Email,
    string? Username,
    string? Password,
    string? ConfirmPassword
);