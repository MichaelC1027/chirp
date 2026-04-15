using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Models;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        //creating new like 
        var existingLike = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        if (existingLike != null)
        {
            throw new Exception("you already liked this post");
        }

        var like = new Like()
        {
            PostId = postId,
            UserId = userId,
            CommentId = null
        };
        
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();

        return new LikeResponse
        {
            PostId = like.PostId,
            UserId = like.UserId,
            CommentId = like.CommentId
        };
    }
    public async Task<LikeResponse> CreateLikeOnComment(int? commentId, int userId)
    {
        var existingLike = await _context.Likes.FirstOrDefaultAsync(l => l.CommentId == commentId && l.UserId == userId);
        if (existingLike != null)
        {
            throw new Exception("you already liked this comment");
        }

        var like = new Like()
        {
            PostId = null,
            UserId = userId,
            CommentId = commentId
        };
        
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();
        
        return new LikeResponse
        {
            PostId = like.PostId,
            UserId = like.UserId,
            CommentId = like.CommentId
        };
    }

    public async Task<bool> DeleteLikeOnPost(int? postId, int userId)
    {
        var existingLike = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
        if (existingLike == null)
        {
            throw new Exception("you have not liked this post");
        }
        
        _context.Likes.Remove(existingLike);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteLikeOnComment(int? commentId, int userId)
    {
        var existingLike = await _context.Likes.FirstOrDefaultAsync(l => l.CommentId == commentId && l.UserId == userId);
        if (existingLike == null)
        {
            throw new Exception("you have not liked this comment");
        }
        
        _context.Likes.Remove(existingLike);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<LikeResponse>> GetLikesOnPosts(int postId)
    {
        var likes = await _context.Likes.Where(l => l.PostId == postId).ToListAsync();
        return likes.Select(l => new LikeResponse
        {
            PostId = l.PostId,
            UserId = l.UserId
        });
    }
    
    public async Task<IEnumerable<LikeResponse>> GetLikesOnComments(int commentId)
    {
        var likes = await _context.Likes.Where(l => l.CommentId == commentId).ToListAsync();
        return likes.Select(l => new LikeResponse
        {
            UserId = l.UserId,
            CommentId = l.CommentId
        });
    }
}