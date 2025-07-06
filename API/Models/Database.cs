namespace API.Models.Data;

public record User(int Id, string Username, string Email, string PasswordHash, DateTime CreatedAt);
public record Post(int Id, string Title, string Slug, string Body, bool Published, DateTime CreatedAt, DateTime UpdatedAt);