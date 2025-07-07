namespace API.Services.MediaService;

public interface IMediaService
{
    Task<string> UploadAsync(Stream fileStream, string fileName,
        string contentType, int postId, string postSlug);
}