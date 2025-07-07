namespace API.Services.Comment;

using Models.Comment;

public interface ICommentService
{
    Task<CommentViewModel> CreateCommentAsync(CreateCommentRequest request, int userId);
    Task<List<CommentViewModel>> ListByPostAsync(int postId);
    Task<bool> DeleteCommentAsync(int commentId);
}