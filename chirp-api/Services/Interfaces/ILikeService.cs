using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface ILikeService
{
    Task<LikeResponse> CreateLikeOnPost(int? postId, int userId);
    Task<LikeResponse> CreateLikeOnComment(int? commentId, int userId);
    Task<bool> DeleteLikeOnPost(int? postId, int userId);
    Task<bool> DeleteLikeOnComment(int? commentId, int userId);
    Task<IEnumerable<LikeResponse>> GetLikesOnPosts(int postId);
    Task<IEnumerable<LikeResponse>> GetLikesOnComments(int commentId);
}