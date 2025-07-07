namespace API.Services.Post;

using Models;
using Models.Data;
using Models.Post;

public interface IPostService
{
    Task<Post?> GetBySlugAsync(string slug);
    Task<IEnumerable<PostItem>> GetAllAsync(bool includeDrafts = false);
    Task<Post> CreateAsync(CreatePostRequest request);
    Task<Post?> UpdateAsync(int postId, UpdatePostRequest request);
    Task<bool> DeleteAsync(int postId);
}