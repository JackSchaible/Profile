namespace API.Controllers;

using API.Services.Auth;
using API.Models.Auth;

public static class AuthController
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
        {
            if (request.Email == null || request.Password == null)
            {
                return Results.BadRequest("Email and Password are required.");
            }

            string? token = await authService.LoginAsync(request);

            if (token == null)
            {
                return Results.Unauthorized();
            }

            return Results.Ok(new { token });
        });
    }
}