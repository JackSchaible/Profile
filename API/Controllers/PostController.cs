namespace API.Controllers;

using Models;
using Models.Data;
using Models.Post;
using Services.Post;

public static class PostController
{
    public static void MapPostEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/post");

        group.MapGet("/", async (IPostService postService) =>
            Results.Ok(await postService.GetAllAsync()));

        group.MapGet("/{slug}", async (string slug, IPostService postService) =>
        {
            Post? post = await postService.GetBySlugAsync(slug);
            return post is not null ? Results.Ok(post) : Results.NotFound();
        });
        
        group.MapPost("/", async (CreatePostRequest request, IPostService postService) =>
        {
            Post post = await postService.CreateAsync(request);
            return Results.Created($"/post/{post.Slug}", post);
        }).RequireAuthorization();
        
        group.MapPut("/{postId:int}", async (int postId, UpdatePostRequest request, IPostService postService) =>
        {
            if (postId != request.PostId)
                return Results.BadRequest("Post ID in the URL does not match the request body.");
            
            Post? updatedPost = await postService.UpdateAsync(postId, request);
            return updatedPost is null ? 
                Results.NotFound() :
                Results.Ok(updatedPost);
        }).RequireAuthorization();
        
        group.MapDelete("/{postId:int}", async (int postId, IPostService postService) =>
        {
            bool deleted = await postService.DeleteAsync(postId);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).RequireAuthorization();
    }
}