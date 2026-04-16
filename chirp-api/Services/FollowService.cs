using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Models;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace chirp_api.Services;

public class FollowService : IFollowService
{
    private readonly AppDbContext _context;
    
    public FollowService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateFollow(int followerId, int followingId)
    {
        //checking if the user is trying to follow themselves
        if(followerId == followingId)
        {
            throw new Exception("you cannot follow yourself");
        }
        
        var existingFollow = await _context.Follows.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);
        if(existingFollow != null)
        {
            throw new Exception("you are already following this user");
        }

        var follower = new Follow
        {
            FollowerId = followerId,
            FollowingId = followingId
        };
        
        await _context.Follows.AddAsync(follower);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<FollowResponse>> GetFollowers(int userId)
    {
        return await _context.Follows.Where(f => f.FollowingId == userId)
            .Join(_context.Users, f => f.FollowerId, u => u.Id, (f, u) => new FollowResponse
            {
                UserId = u.Id,
                Username = u.Username,
                ProfilePicture = u.ProfilePicture
            }).ToListAsync();
    }

    public async Task<IEnumerable<FollowResponse>> GetFollowing(int userId)
    {
        return await _context.Follows.Where(f => f.FollowerId == userId)
            .Join(_context.Users, f => f.FollowingId, u => u.Id, (f, u) => new FollowResponse
            {
                UserId = u.Id,
                Username = u.Username,
                ProfilePicture = u.ProfilePicture
            }).ToListAsync();
    }

    public async Task<bool> DeleteFollow(int followerId, int followingId)
    {
        var existingFollow = await _context.Follows.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);
        if (existingFollow == null)
        {
            throw new Exception("you are not following this user");
        }
        
        _context.Follows.Remove(existingFollow);
        await _context.SaveChangesAsync();
        return true;
    }
}