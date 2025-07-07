namespace API.Services.MediaService;

using Dapper;
using Microsoft.Data.SqlClient;
using Storage;

public class MediaService(IStorageService storageService, string connectionString)
    : IMediaService
{
    private readonly string _connectionString = connectionString;

    public async Task<string> UploadAsync(Stream fileStream, string fileName,
        string contentType, int postId, string postSlug)
    {
        string url = await storageService.UploadFileAsync(fileStream, fileName,
            contentType, postSlug);

        await using SqlConnection conn = new(_connectionString);

        const string sql = """
       INSERT INTO Media (PostId, Url, Type, CreatedAt)
       VALUES (@PostId, @Url, @Type, @Date);
       """;

        await conn.ExecuteAsync(sql, new
        {
            PostId = postId,
            Url = url,
            Type = contentType,
            Date = DateTime.UtcNow
        });

        return url;
    }
}