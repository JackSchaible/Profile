namespace API.Controllers;

using System.Security.Claims;
using Models.User;
using Services.User;

public static class UserController
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/user");

        group.MapPut("/changeUsername", async (
            UpdateUsernameRequest request,
            IUserService userService,
            ClaimsPrincipal user) =>
        {
            int userId = int.Parse(
                user.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new InvalidOperationException("User ID not found in claims."));

            string? token = await userService.UpdateUsernameAsync(userId,
                request.NewUsername);
            
            return token is null
                ? Results.BadRequest("Update failed.")
                : Results.Ok(new { token });
            
        }).RequireAuthorization();
    }
}