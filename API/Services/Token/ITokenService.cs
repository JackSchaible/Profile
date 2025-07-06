using API.Models.Data;

namespace API.Services.Token;

public interface ITokenService
{
    /// <summary>
    /// Generates a JWT token for the given user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A JWT token as a string.</returns>
    string GenerateToken(User user);

    /// <summary>
    /// Validates the given JWT token.
    /// </summary>
    /// <param name="token">The JWT token to validate.</param>
    /// <returns>True if the token is valid, otherwise false.</returns>
    bool ValidateToken(string token);
}