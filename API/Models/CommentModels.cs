namespace API.Models.Comment;

public record CreateCommentRequest(int PostId, int? ParentId, string Content);
public record CommentViewModel(int UserId, string Username, string Content,
    DateTime CreatedAt, int? ParentId, List<CommentViewModel> Replies);