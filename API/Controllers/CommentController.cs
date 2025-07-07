namespace API.Controllers;

using System.Security.Claims;
using Models.Comment;
using Services.Comment;

public static class CommentController
{
    public static void MapCommentEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/comment");

        group.MapPost("/", async (
            CreateCommentRequest request,
            ICommentService commentService,
            ClaimsPrincipal user) =>
        {
            if (!int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
                return Results.Unauthorized();

            CommentViewModel comment = await commentService.CreateCommentAsync(request, userId);
            return Results.Ok(comment);
        }).RequireAuthorization();
        
        group.MapGet("/post/{postId:int}", async (
            int postId,
            ICommentService commentService) =>
        {
            List<CommentViewModel> comments = await commentService.ListByPostAsync(postId);
            return Results.Ok(comments);
        });
        
        group.MapDelete("/{commentId:int}", async (
            int commentId,
            ClaimsPrincipal user,
            ICommentService commentService) =>
        {
            string? adminEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL");
            if (adminEmail is null ||
                user.FindFirst(ClaimTypes.Email)?.Value != adminEmail)
                return Results.Forbid();
            
            bool deleted = await commentService.DeleteCommentAsync(commentId);
            return deleted ? Results.Ok() : Results.NotFound();

        }).RequireAuthorization();
    }
}