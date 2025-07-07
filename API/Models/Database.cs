namespace API.Models.Data;

public record User(int Id, string Username, string Email, string PasswordHash, DateTime CreatedAt);
public record Post(int Id, string Title, string Slug, string Body, bool Published, DateTime CreatedAt, DateTime UpdatedAt);
public record Comment(int Id, int UserId, string Username, int PostId, int? ParentId, string Content, DateTime CreatedAt);