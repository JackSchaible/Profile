namespace API.Services.Storage;

using Amazon.S3;
using Amazon.S3.Transfer;

public class S3StorageService(string bucketName) : IStorageService
{
    private readonly IAmazonS3 _s3Client = new AmazonS3Client();

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType, string postSlug)
    {
        string key = $"media/{postSlug}/{Guid.NewGuid()}_{fileName}";

        TransferUtilityUploadRequest uploadRequest = new TransferUtilityUploadRequest
        {
            InputStream = fileStream,
            Key = key,
            BucketName = bucketName,
            ContentType = contentType,
            CannedACL = S3CannedACL.PublicRead
        };

        TransferUtility fileTransferUtility = new TransferUtility(_s3Client);
        await fileTransferUtility.UploadAsync(uploadRequest);

        return $"https://{bucketName}.s3.amazonaws.com/{key}";
    }
}