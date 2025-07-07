namespace API.Services.Post;

using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Models.Data;
using Models.Post;

public class PostService(string connectionString) : IPostService
{
    public async Task<Post?> GetBySlugAsync(string slug)
    {
        await using SqlConnection conn = new (connectionString);
        return await conn.QuerySingleOrDefaultAsync<Post>(
            """
            SELECT [Id], [Title], [Slug], [Body], [Published], [CreatedAt], [UpdatedAt]
            FROM [dbo].[Posts]
            WHERE [Slug] = @Slug;
            """,
            new { Slug = slug });
    }

    public async Task<IEnumerable<PostItem>> GetAllAsync(
        bool includeDrafts = false)
    {
        await using SqlConnection conn = new(connectionString);
        const string sql =
            """
            SELECT [Id], [Title], [Slug], [UpdatedAt]
            FROM [dbo].[Posts]
            WHERE [Published] = 1
            ORDER BY [UpdatedAt] DESC;
            """;

        return await conn.QueryAsync<PostItem>(
            sql
        );
    }

    public async Task<Post> CreateAsync(CreatePostRequest request)
    {
        await using SqlConnection conn = new (connectionString);
        
        const string sql = 
            """
           INSERT INTO [dbo].[Posts] (Title, Slug, Body, Published, CreatedAt, UpdatedAt)
           OUTPUT INSERTED.*
           VALUES (@Title, @Slug, @Body, @Published, @CreatedAt, @UpdatedAt);
           """;
        
        return await conn.QuerySingleAsync<Post>(
            sql,
            new
            {
                request.Title,
                Slug = GenerateSlug(request.Title),
                Body = request.Content,
                Published = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            }
        );
    }

    public async Task<Post?> UpdateAsync(int postId, UpdatePostRequest request)
    {
        await using SqlConnection conn = new(connectionString);
        
        const string sql =
            """
            UPDATE [dbo].[Posts]
            SET Title = @Title, Slug = @Slug, Body = @Body, Published = @Published, UpdatedAt = @UpdatedAt
            OUTPUT INSERTED.*
            WHERE Id = @PostId;
            """;

        return await conn.QuerySingleOrDefaultAsync<Post>(
            sql,
            new
            {
                request.Title,
                Slug = GenerateSlug(request.Title),
                Body = request.Content,
                Published = request.Published,
                UpdatedAt = DateTime.UtcNow,
            }
        );
    }
    

    public async Task<bool> DeleteAsync(int postId)
    {
        await using SqlConnection conn = new (connectionString);
        
        const string sql = 
            """
            DELETE FROM [dbo].[Posts]
            WHERE Id = @PostId;
            """;

        int rowsAffected = await conn.ExecuteAsync(
            sql,
            new { PostId = postId });
        
        return rowsAffected > 0;
    }

    private static string GenerateSlug(string title) => 
        title
            .ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("'", "")
            .Replace("\"", "")
            .Replace(",", "")
            .Replace(".", "")
            .Replace("!", "")
            .Replace("?", "");
}