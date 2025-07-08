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


string jwtSecret = builder.Configuration["Jwt:Secret"] ?? throw new InvalidOperationException("Jwt:Secret is not set in configuration.");
string sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("DefaultConnection connection string is not set in configuration.");
string bucketName = builder.Configuration["AWS:BucketName"] ?? throw new InvalidOperationException("AWS:BucketName is not set in configuration.");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    jwtSecret)),
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