using System.Text;
using API.Controllers;
using API.Seeds;
using API.Services.Auth;
using API.Services.Comment;
using API.Services.Post;
using API.Services.Storage;
using API.Services.Token;
using API.Services.User;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

string jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new InvalidOperationException("JWT_SECRET environment variable is not set.");
string sqlConnectionString = Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? throw new InvalidOperationException("SQL_CONNECTION_STRING environment variable is not set.");
string bucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME") ?? throw new InvalidOperationException("AWS_BUCKET_NAME environment variable is not set.");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    Environment.GetEnvironmentVariable("JWT_SECRET") ?? throw new InvalidOperationException("JWT_SECRET environment variable is not set."))),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddSingleton<ITokenService, TokenService>(sp => new TokenService(jwtSecret, sqlConnectionString));
builder.Services.AddSingleton<IStorageService, S3StorageService>(sp => new S3StorageService(bucketName));
builder.Services.AddScoped<IAuthService, AuthService>(sp => new AuthService(sqlConnectionString, sp.GetRequiredService<ITokenService>()));
builder.Services.AddScoped<IUserService, UserService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    ITokenService tokenService = sp.GetRequiredService<ITokenService>();
    return new UserService(sqlConnectionString, tokenService);
});
builder.Services.AddScoped<IPostService, PostService>(sp => new PostService(sqlConnectionString));
builder.Services.AddScoped<ICommentService, CommentService>(sp => new CommentService(sqlConnectionString));

WebApplication app = builder.Build();

app.Logger.LogInformation("Starting Profile Blog API...");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapAuthEndpoints();
app.MapUserEndpoints();
app.MapPostEndpoints();
app.MapCommentEndpoints();
app.MapMediaEndpoints();

app.MapGet("/ping", () => "PONG!");

await AdminSeeder.SeedAsync(app, sqlConnectionString);

app.Run();
app.Logger.LogInformation("Profile Blog API started successfully.");