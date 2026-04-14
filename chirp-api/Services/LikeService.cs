using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class LikeService : ILikeService
{
    private readonly AppDbContext _context;
    
    public LikeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LikeResponse> CreateLikeOnPost(int? postId, int userId)
    {
        throw new NotImplementedException();
    }
    public async Task<LikeResponse> CreateLikeOnComment(int? commentId, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteLikeOnPost(int? postId, int userId)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteLikeOnComment(int? commentId, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<LikeResponse>> GetLikes(int postId)
    {
        throw new NotImplementedException();
    }
}