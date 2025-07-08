namespace API.Controllers;

using System.Security.Claims;
using Microsoft.AspNetCore.Identity.Data;
using Services.Auth;
using Models.Auth;
using Services.Token;
using LoginRequest = Models.Auth.LoginRequest;
using RegisterRequest = Models.Auth.RegisterRequest;

public static class AuthController
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/auth");

        group.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
        {
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return Results.BadRequest("Email and Password are required.");
            }

            TokenPair? tokens = await authService.LoginAsync(request);

            return tokens == null ?
                Results.Unauthorized() :
                Results.Ok(new { tokens });
        });

        group.MapPost("/register", async (RegisterRequest request, IAuthService authService) =>
        {
            if (string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                return Results.BadRequest("All fields are required.");
            }

            TokenPair? result = await authService.RegisterAsync(request);

            return result == null ?
                Results.Conflict("Email already taken.") :
                Results.Ok(new { result });
        });

        group.MapPut("/password", async (
            UpdatePasswordRequest request,
            ClaimsPrincipal user,
            IAuthService authService
        ) =>
        {
            int userId = int.Parse(
                user.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new InvalidOperationException("User ID not found in claims."));
            
            if (string.IsNullOrWhiteSpace(request.OldPassword) || string.IsNullOrWhiteSpace(request.NewPassword))
                return Results.BadRequest("Old and new passwords are required.");
            
            bool success = await authService.UpdatePasswordAsync(request, userId);
            return Results.Ok(new { success });
        }).RequireAuthorization();

        group.MapPost("/token/refresh", async (
            RefreshRequest rr,
            ClaimsPrincipal user,
            ITokenService tokenService,
            IAuthService auth) =>
        {
            TokenPair? tokens =
                await tokenService.RefreshTokensAsync(rr.RefreshToken, auth.IsAdmin(user));
                
            return tokens is null ?
                Results.Unauthorized() :
                Results.Ok(tokens);
        }).RequireAuthorization();
        
        group.MapPost("/logout", async (
            string refreshToken,
            ClaimsPrincipal user,
            IAuthService auth) =>
        {
            int userId = int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new InvalidOperationException("User ID not found in claims."));
            bool result = await auth.LogoutAsync(userId, refreshToken);

            return result ? Results.Ok() : Results.BadRequest("Invalid token.");
        }).RequireAuthorization();
    }
}