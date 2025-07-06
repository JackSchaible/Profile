namespace API.Models;

public record PostItem(int id, string Title, string Slug, DateTime UpdatedAt);
public record CreatePostRequest(string Title, string Content);
public record UpdatePostRequest(int PostId, string Title, string Content, bool Published);