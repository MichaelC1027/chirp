using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface ICommentService
{
    Task<CommentResponse> CreateComment(int postId, string content, int userId);
    Task<bool> DeleteComment(int commentId);
    Task<IEnumerable<CommentResponse>> GetCommentsByPost(int postId);
    Task<CommentResponse> UpdateComment(int commentId, string content);
    Task<CommentResponse> GetComment(int commentId);
}