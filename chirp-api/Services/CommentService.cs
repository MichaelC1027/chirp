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
        var comment = new Comment()
        {
            PostId = postId,
            Content = content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            LikeCount = 0,
            ReplyCount = 0
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
            LikeCount = comment.LikeCount,
            ReplyCount = comment.ReplyCount
        };

    }

    public async Task<bool> DeleteComment(int commentId)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("comment not found");
        }
        
        _context.Comments.Remove(existingComment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsByPost(int postId)
    {
        var comments = await _context.Comments.Where(w => w.PostId == postId).OrderBy(w => w.CreatedAt).ToListAsync();
        return comments.Select(c => new CommentResponse
        {
            Id = c.Id,
            PostId = c.PostId,
            Content = c.Content,
            UserId = c.UserId,
            CreatedAt = c.CreatedAt,
            LikeCount = c.LikeCount,
            ReplyCount = c.ReplyCount
            
        });

    }

    public async Task<CommentResponse> UpdateComment(int commentId, string content)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("comment not found");
        }
        
        existingComment.Content = content;
        await _context.SaveChangesAsync();

        return new CommentResponse
        {
            Id = existingComment.Id,
            PostId = existingComment.PostId,
            Content = existingComment.Content,
            UserId = existingComment.UserId,
            CreatedAt = existingComment.CreatedAt,
            LikeCount = existingComment.LikeCount,
            ReplyCount = existingComment.ReplyCount
        };
    }

    public async Task<CommentResponse> GetComment(int commentId)
    {
        var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (existingComment == null)
        {
            throw new Exception("Comment not found");
        }
        
        return new CommentResponse
        {
            Id = existingComment.Id,
            PostId = existingComment.PostId,
            Content = existingComment.Content,
            UserId = existingComment.UserId,
            CreatedAt = existingComment.CreatedAt,
            LikeCount = existingComment.LikeCount,
            ReplyCount = existingComment.ReplyCount
        };
    }
}