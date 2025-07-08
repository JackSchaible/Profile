namespace API.Models.Data;

public record User
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PasswordHash { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    
    public User() { }
    public User(int id, string username, string email, string passwordHash, DateTime createdAt)
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = createdAt;
    }
}

public record Post
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Slug { get; init; } = string.Empty;
    public string Body { get; init; } = string.Empty;
    public bool Published { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    public Post() { }
    public Post(int id, string title, string slug, string body, bool published, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Title = title;
        Slug = slug;
        Body = body;
        Published = published;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}

public record Comment
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public int PostId { get; init; }
    public int? ParentId { get; init; }
    public string Content { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }

    public Comment() { }
    public Comment(int id, int userId, string username, int postId, int? parentId, string content, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        Username = username;
        PostId = postId;
        ParentId = parentId;
        Content = content;
        CreatedAt = createdAt;
    }
}