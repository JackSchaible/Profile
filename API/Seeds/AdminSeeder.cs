namespace API.Seeds;

using Dapper;
using Microsoft.Data.SqlClient;
using BCrypt.Net;

internal static class AdminSeeder
{
    public static async Task SeedAsync(WebApplication app, string sqlConnectionString)
    {
        IConfiguration config = app.Services.GetRequiredService<IConfiguration>();
        app.Logger.LogInformation("Seeding admin user in development environment.");
    

        string defaultEmail, defaultUsername, rawPassword;
        if (app.Environment.IsDevelopment())
        {
            defaultEmail = config["Admin:Email"] ?? "admin@example.com";
            defaultUsername = config["Admin:Username"] ?? "admin";
            rawPassword = config["Admin:Password"] ?? string.Empty;
        }
        else
        {
            defaultEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL") ?? "admin@example.com";
            defaultUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME") ?? "admin";
            rawPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD") ?? string.Empty;
        }

        if (string.IsNullOrWhiteSpace(rawPassword))
        {
            app.Logger.LogError("ADMIN_PASSWORD env var is not set. Skipping admin user seed.");
            return;
        }

        if (string.IsNullOrWhiteSpace(defaultEmail))
        {
            app.Logger.LogError("ADMIN_EMAIL env var is not set. Skipping admin user seed.");
            return;
        }

        if (string.IsNullOrWhiteSpace(defaultUsername))
        {
            app.Logger.LogWarning("ADMIN_USERNAME env var is not set. Using default 'admin'.");
            defaultUsername = "admin";
        }

        await using SqlConnection conn = new(sqlConnectionString);
        await conn.OpenAsync();

        int existing = await conn.ExecuteScalarAsync<int>(
            "SELECT COUNT(1) FROM Users WHERE Email = @Email",
            new { Email = defaultEmail });

        if (existing > 0)
        {
            app.Logger.LogInformation("Admin user already exists. Skipping seed.");
            return;
        }

        string? hash = BCrypt.HashPassword(rawPassword);

        await conn.ExecuteAsync(
            "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)",
            new { Username = defaultUsername, Email = defaultEmail, PasswordHash = hash });

        app.Logger.LogInformation("Seeded default admin user.");
    }
}


