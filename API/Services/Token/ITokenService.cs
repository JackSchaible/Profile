namespace API.Services.Token;

using Microsoft.Data.SqlClient;
using Models.Auth;
using Models.Data;

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

    /// <summary>
    /// Issues a new pair of access (JWT) and refresh tokens for the specified valid user.
    /// </summary>
    /// <param name="user">The user for whom to issue tokens.</param>
    /// <returns>A <see cref="TokenPair"/> containing the access and refresh tokens.</returns>
    Task<TokenPair> IssueTokens(User user);
    
    ///<summary>
    /// Issues a new pair of access (JWT) and refresh tokens by validating the provided refresh token, deleting the old refresh token, and generating a new token pair.
    ///</summary>
    ///<param name="refreshToken">The refresh token to validate and exchange.</param>
    ///<returns>A <see cref="TokenPair"></see> containing the new access and refresh tokens, or null if the refresh exchange was unsuccessful.</returns>
    Task<TokenPair?> RefreshTokensAsync(string refreshToken);
}