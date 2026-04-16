using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface ICommentService
{
    Task<CommentResponse> CreateComment(int postId, string content, int userId);
    Task<bool> DeleteComment(int commentId, int userId);
    Task<IEnumerable<CommentResponse>> GetCommentsByPost(int postId);
    Task<CommentResponse> UpdateComment(int commentId, string content, int userId);
    Task<CommentResponse> GetComment(int commentId);
}