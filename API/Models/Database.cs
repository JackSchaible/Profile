namespace API.Models.Data;

public record User(int Id, string Username, string Email, string PasswordHash, DateTime CreatedAt);