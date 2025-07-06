namespace API.Seeds;

using Dapper;
using Microsoft.Data.SqlClient;
using BCrypt.Net;

static class AdminSeeder
{
    public static async Task SeedAsync(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.Logger.LogInformation("Seeding admin user in development environment.");
            await SeedAdminUser(app);
        }
        else
        {
            app.Logger.LogInformation("Skipping admin user seed in production environment.");
        }
    }

    private static async Task SeedAdminUser(WebApplication app)
    {
        var config = app.Services.GetRequiredService<IConfiguration>();
        var connStr = config.GetConnectionString("Default");

        var defaultEmail = "admin@example.com"; // You can env-var this too
        var defaultUsername = "admin";

        var rawPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

        if (string.IsNullOrWhiteSpace(rawPassword))
        {
            app.Logger.LogWarning("ADMIN_PASSWORD env var is not set. Skipping admin user seed.");
            return;
        }

        using var conn = new SqlConnection(connStr);
        await conn.OpenAsync();

        var existing = await conn.ExecuteScalarAsync<int>(
            "SELECT COUNT(1) FROM Users WHERE Email = @Email",
            new { Email = defaultEmail });

        if (existing > 0)
        {
            app.Logger.LogInformation("Admin user already exists. Skipping seed.");
            return;
        }

        var hash = BCrypt.Net.BCrypt.HashPassword(rawPassword);

        await conn.ExecuteAsync(
            "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)",
            new { Username = defaultUsername, Email = defaultEmail, PasswordHash = hash });

        app.Logger.LogInformation("Seeded default admin user.");
    }
}


