namespace API.Seeds;

using Dapper;
using Microsoft.Data.SqlClient;
using BCrypt.Net;

internal static class AdminSeeder
{
    public static async Task SeedAsync(WebApplication app, string sqlConnectionString)
    {
        app.Logger.LogInformation("Seeding admin user in development environment.");
        
        string defaultEmail = Environment.GetEnvironmentVariable("ADMIN_EMAIL") ?? "admin@example.com";
        string defaultUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME") ?? "admin";
        string? rawPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

        if (string.IsNullOrWhiteSpace(rawPassword))
        {
            app.Logger.LogWarning("ADMIN_PASSWORD env var is not set. Skipping admin user seed.");
            return;
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


