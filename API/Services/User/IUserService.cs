namespace API.Services.User;

public interface IUserService
{
    Task<string?> UpdateUsernameAsync(int userId, string newUsername);
}