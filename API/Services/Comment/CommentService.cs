namespace API.Services.Comment;

using Dapper;
using Microsoft.Data.SqlClient;
using Models.Comment;
using Models.Data;

public class CommentService(string connectionString) : ICommentService
{
    public async Task<CommentViewModel> CreateCommentAsync(CreateCommentRequest request, int userId)
    {
        await using SqlConnection connection = new(connectionString);
        await connection.OpenAsync();
        
        const string sql = """
            INSERT INTO [dbo].[Comments] (PostId, ParentId, Body, CreatedAt, UserId)
            OUTPUT INSERTED.Id
            VALUES (@PostId, @ParentId, @Body, @CreatedAt, @UserId);
        """;
        
        int commentId = await connection.ExecuteScalarAsync<int>(sql, new
        {
            request.PostId,
            UserId = userId,
            ParentId = request.ParentId,
            Body = request.Content,
            CreatedAt = DateTime.UtcNow
        });
        
        string username = await connection.QuerySingleAsync<string>(
            "SELECT Username FROM [dbo].[Users] WHERE Id = @UserId", new { UserId = userId });
        
        return new CommentViewModel(userId, username, request.Content,
            DateTime.UtcNow, request.ParentId,[]);
    }

    public async Task<List<CommentViewModel>> ListByPostAsync(int postId)
    {
        await using SqlConnection connection = new(connectionString);
        await connection.OpenAsync();
        
        const string sql = """
            SELECT c.Id, c.UserId, u.Username, c.PostId, c.Body, c.CreatedAt
            FROM [dbo].[Comments] c
            JOIN [dbo].[Users] u ON c.UserId = u.Id
            WHERE c.PostId = @PostId
            ORDER BY c.CreatedAt DESC;
        """;
        
        List<Comment> flat =
            (await connection.QueryAsync<Comment>(
                    sql,
                    new { PostId = postId }))
            .ToList();
        
        Dictionary<int, CommentViewModel> dict = flat.ToDictionary(
            c => c.Id,
            c => new CommentViewModel(c.UserId, c.Username, c.Content,
                c.CreatedAt, c.ParentId, []));
        
        List<CommentViewModel> roots = [];
        
        foreach (CommentViewModel comment in dict.Values)
        {
            if (comment.ParentId is null)
                roots.Add(comment);
            else if (dict.TryGetValue(comment.ParentId.Value, out CommentViewModel? parent))
                parent.Replies.Add(comment);
        }
        
        return roots
            .OrderByDescending(c => c.CreatedAt)
            .ToList();
    }

    public async Task<bool> DeleteCommentAsync(int commentId)
    {
        await using SqlConnection conn = new (connectionString);
        await conn.OpenAsync();
        bool exists = await conn.ExecuteScalarAsync<bool>(
            "SELECT 1 FROM Comments WHERE Id = @Id",
            new { Id = commentId });

        if (!exists)
            return false;

        const string sql = """
        WITH RecursiveComments AS (
            SELECT Id
            FROM Comments
            WHERE Id = @RootId
            UNION ALL
            SELECT c.Id
            FROM Comments c
            INNER JOIN RecursiveComments rc ON c.ParentId = rc.Id
        )
        DELETE FROM Comments
        WHERE Id IN (SELECT Id FROM RecursiveComments)
        """;

        await conn.ExecuteAsync(sql, new { RootId = commentId });
        return true;
    }
}