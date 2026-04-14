using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface IFollowService
{
    Task<FollowResponse> CreateFollow(int followerId, int followingId);
    Task<IEnumerable<FollowResponse>> GetFollowers(int userId);
    Task<IEnumerable<FollowResponse>> GetFollowing(int userId);
    Task<bool> DeleteFollow(int followerId, int followingId);
}
