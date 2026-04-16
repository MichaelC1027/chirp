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
        //checking if the post exists
        if(postId == null){ throw new Exception("postId is required"); }
        
        //checking if the post is even in the DB
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("post not found");
        }
        
        
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
            Id = like.Id,
            PostId = like.PostId,
            UserId = like.UserId,
            CommentId = like.CommentId
        };
    }
    public async Task<LikeResponse> CreateLikeOnComment(int? commentId, int userId)
    {
        //checking if the comment exists
        if(commentId == null){ throw new Exception("comment not found"); }
        
        //check if the comment is even in the DB
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("comment not found");
        }
        
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
            Id = like.Id,
            PostId = like.PostId,
            UserId = like.UserId,
            CommentId = like.CommentId
        };
    }

    public async Task<bool> DeleteLikeOnPost(int? postId, int userId)
    {
        //checking if the post exists
        if(postId == null){ throw new Exception("post not found"); }
        
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
        //checking if the comment exists
        if(commentId == null){ throw new Exception("comment not found"); }
        
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
            Id = l.Id,
            PostId = l.PostId,
            UserId = l.UserId
        });
    }
    
    public async Task<IEnumerable<LikeResponse>> GetLikesOnComments(int commentId)
    {
        var likes = await _context.Likes.Where(l => l.CommentId == commentId).ToListAsync();
        return likes.Select(l => new LikeResponse
        {
            Id = l.Id,
            UserId = l.UserId,
            CommentId = l.CommentId
        });
    }
}