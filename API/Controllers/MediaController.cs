namespace API.Controllers;

using System.Security.Claims;
using API.Services.Auth;
using Services.MediaService;
using Services.Post;

public static class MediaController
{
    public static void MapMediaEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/media")
            .WithTags("Media");

        group.MapPut("/upload", async (
            HttpContext context,
            IMediaService service,
            IAuthService authService,
            IPostService postService,
            ClaimsPrincipal user) =>
        {
            if (!authService.IsAdmin(user))
                return Results.Forbid();
            
            IFormCollection form = await context.Request.ReadFormAsync();
            if (!form.Files.Any())
                return Results.BadRequest("No files uploaded.");
            
            IFormFile file = form.Files[0];
            if (file.Length == 0)
                return Results.BadRequest("File is empty.");
            
            if (!int.TryParse(form["postId"], out int postId))
                return Results.BadRequest("Missing postId or postSlug.");
            
            string postSlug = await postService.GetSlugForByIdAsync(postId);
            string mediaType = form["mediaType"].ToString() ?? "unknown";
            
            if (string.IsNullOrWhiteSpace(postSlug))
                return Results.BadRequest("Invalid post ID.");
            
            await using Stream stream = file.OpenReadStream();
            string? mediaUrl = await service.UploadAsync(stream, file.FileName,
                mediaType, postId, postSlug);
            
            return mediaUrl is not null ?
                Results.Ok(new { mediaUrl }) :
                Results.BadRequest("Failed to upload media.");
        })
        .Accepts<IFormFile>("multipart/form-data")
        .RequireAuthorization()
        .WithName("UploadMedia");
    }
}