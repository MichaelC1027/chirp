using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Models;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chirp_api.Services;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CommentResponse> CreateComment(int postId, string content, int userId)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("post not found");
        }
        
        var comment = new Comment()
        {
            PostId = postId,
            Content = content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };
        
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return new CommentResponse
        {
            Id = comment.Id,
            PostId = comment.PostId,
            Content = comment.Content,
            UserId = comment.UserId,
            CreatedAt = comment.CreatedAt,
            LikeCount = 0
        };

    }

    public async Task<bool> DeleteComment(int commentId, int userId)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("comment not found");
        }
        if (existingComment.UserId != userId)
        {
            throw new Exception("You are not the owner of this comment. you do not have permission to delete this comment");
        }
        
        _context.Comments.Remove(existingComment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsByPost(int postId)
    {
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }
        
        var comments = await _context.Comments
            .Where(w => w.PostId == postId)
            .OrderBy(w => w.CreatedAt)
            .ToListAsync();
        var commentIds = comments.Select(c => c.Id).ToList();
        
        var likeCounts = await _context.Likes
            .Where(l => l.CommentId != null && commentIds.Contains(l.CommentId!.Value))
            .GroupBy(l => l.CommentId)
            .Select(g => new { CommentId = g.Key, Count = g.Count() })
            .ToListAsync();
        
        return comments.Select(c => new CommentResponse
        {
            Id = c.Id,
            PostId = c.PostId,
            Content = c.Content,
            UserId = c.UserId,
            CreatedAt = c.CreatedAt,
            LikeCount = likeCounts.FirstOrDefault(l => l.CommentId == c.Id)?.Count ?? 0,
        });

    }

    public async Task<CommentResponse> UpdateComment(int commentId, string content, int userId)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("comment not found");
        }
        if (existingComment.UserId != userId)
        {
            throw new Exception("You are not the owner of this comment. you do not have permission to edit this comment");
        }
        
        //getting the like and comment count
        var likeCount = await _context.Likes.CountAsync(l => l.CommentId == commentId);
        
        existingComment.Content = content;
        await _context.SaveChangesAsync();

        return new CommentResponse
        {
            Id = existingComment.Id,
            PostId = existingComment.PostId,
            Content = existingComment.Content,
            UserId = existingComment.UserId,
            CreatedAt = existingComment.CreatedAt,
            LikeCount = likeCount
        };
    }

    public async Task<CommentResponse> GetComment(int commentId)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("Comment not found");
        }
        
        //getting the like and comment count
        var likeCount = await _context.Likes.CountAsync(l => l.CommentId == commentId);
        
        return new CommentResponse
        {
            Id = existingComment.Id,
            PostId = existingComment.PostId,
            Content = existingComment.Content,
            UserId = existingComment.UserId,
            CreatedAt = existingComment.CreatedAt,
            LikeCount = likeCount
        };
    }
}