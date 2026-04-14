using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface IPostService
{
    Task<PostResponse> CreatePost(string content, int userId);
    Task<IEnumerable<PostResponse>> GetPosts();
    Task<PostResponse> GetPost(int postId);
    Task<bool> DeletePost(int postId);
    Task<PostResponse> UpdatePost(int postId, string content);
}