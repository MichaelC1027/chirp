using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class FollowService : IFollowService
{
    private readonly AppDbContext _context;
    
    public FollowService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FollowResponse> CreateFollow(int followerId, int followingId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FollowResponse>> GetFollowers(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<FollowResponse>> GetFollowing(int userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteFollow(int followerId, int followingId)
    {
        throw new NotImplementedException();
    }
}