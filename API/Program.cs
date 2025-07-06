using API.Controllers;
using API.Seeds;
using API.Services.Auth;
using API.Services.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add AWS Lambda support. When application is run in Lambda Kestrel is swapped out as the web server with Amazon.Lambda.AspNetCoreServer. This
// package will act as the webserver translating request and responses between the Lambda event source and ASP.NET Core.
builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
builder.Services.AddSingleton(_ => Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING") ?? throw new InvalidOperationException("SQL_CONNECTION_STRING environment variable is not set."));
builder.Services.AddSingleton<ITokenService, TokenService>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new TokenService(config["JWT_SECRET"] ?? throw new InvalidOperationException("JWT_SECRET configuration is not set."));
});
builder.Services.AddScoped<IAuthService,AuthService>(sp =>
{
    IConfiguration config = sp.GetRequiredService<IConfiguration>();
    ITokenService tokenService = sp.GetRequiredService<TokenService>();
    return new AuthService(
        config["SQL_CONNECTION_STRING"] ?? throw new InvalidOperationException("SQL_CONNECTION_STRING configuration is not set."),
        tokenService
    );
 });

var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapAuthEndpoints();

await AdminSeeder.SeedAsync(app);

app.Run();
