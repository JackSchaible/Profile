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
builder.Services.AddSingleton(_ => Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? throw new InvalidOperationException("SQL_CONNECTION_STRING environment variable is not set."));
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
builder.Services.AddSingleton<ITokenService, TokenService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    return new TokenService(
        config["JWT_SECRET"] ?? throw new InvalidOperationException("JWT_SECRET configuration is not set."),
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set."));
});
builder.Services.AddSingleton<IStorageService, S3StorageService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    return new S3StorageService(config);
});
builder.Services.AddScoped<IAuthService, AuthService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    ITokenService tokenService = sp.GetRequiredService<TokenService>();
    return new AuthService(
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set."),
        tokenService
    );
});
builder.Services.AddScoped<IUserService, UserService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    ITokenService tokenService = sp.GetRequiredService<TokenService>();
    return new UserService(
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set."),
        tokenService
    );
});
builder.Services.AddScoped<IPostService, PostService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    return new PostService(
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set.")
    );
});
builder.Services.AddScoped<ICommentService, CommentService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    return new CommentService(
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set.")
    );
});

WebApplication app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapAuthEndpoints();
app.MapUserEndpoints();
app.MapPostEndpoints();
app.MapCommentEndpoints();
app.MapMediaEndpoints();

app.MapGet("/ping", () => "PONG!");

await AdminSeeder.SeedAsync(app);

app.Run();
