namespace API.Services.User;

using Dapper;
using Microsoft.Data.SqlClient;
using Models.Data;
using Token;

public class UserService(string connectionString, ITokenService tokenService)
    : IUserService
{
    public async Task<string?> UpdateUsernameAsync(int userId, string newUsername)
    {
        await using SqlConnection connection = new(connectionString);

        int rows = await connection.ExecuteAsync(
            """
            UPDATE [dbo].[Users]
            SET [Username] = @Username
            WHERE [Id] = @UserId;
            """,
            new { UserId = userId, Username = newUsername });

        if (rows == 0)
            return null;
        
        User user = await connection.QuerySingleAsync<User>(
            """
                SELECT [Id], [Username], [Email], [PasswordHash], [CreatedAt]
                FROM [dbo].[Users]
                WHERE [Id] = @UserId
            """,
            new { UserId = userId });
        
        return tokenService.GenerateToken(user);
    }
}