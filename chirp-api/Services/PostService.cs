using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Models;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chirp_api.Services;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    
    public PostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PostResponse> CreatePost(string content, int userId)
    {
        
        //creating a new post 
        var post = new Post
        {
            Content = content,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };
        
        //adding to the database
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        
        //return
        return new PostResponse
        {
            Id = post.Id,
            Content = post.Content,
            UserId = post.UserId,
            CreatedAt = post.CreatedAt,
            LikeCount = 0,
            CommentCount = 0
        };
    }

    public async Task<IEnumerable<PostResponse>> GetPosts()
    {
        var posts = await _context.Posts.OrderByDescending(p => p.CreatedAt).ToListAsync();
        
        //getting the like and comment count
        var postIds = posts.Select(p => p.Id).ToList();
        var likeCounts = await _context.Likes
            .Where(l => l.PostId != null && postIds.Contains(l.PostId!.Value))
            .GroupBy(l => l.PostId)
            .Select(g => new { PostId = g.Key, Count = g.Count() })
            .ToListAsync();

        var commentCounts = await _context.Comments
            .Where(c => postIds.Contains(c.PostId))
            .GroupBy(c => c.PostId)
            .Select(g => new { PostId = g.Key, Count = g.Count() })
            .ToListAsync();
        
        return posts.Select(p => new PostResponse
        {
            Id = p.Id,
            Content = p.Content,
            UserId = p.UserId,
            CreatedAt = p.CreatedAt,
            LikeCount = likeCounts.FirstOrDefault(l => l.PostId == p.Id)?.Count ?? 0,
            CommentCount = commentCounts.FirstOrDefault(c => c.PostId == p.Id)?.Count ?? 0
        });
    }

    public async Task<PostResponse> GetPost(int postId)
    {
        //searching for the post ID
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found"); //throwing an exception
        }
        
        //getting the like and comment count
        var likeCount = await _context.Likes.CountAsync(l => l.PostId == postId);
        var commentCount = await _context.Comments.CountAsync(c => c.PostId == postId);
        
        //returning the post by ID
        return new PostResponse
        {
            Id = existingPost.Id,
            Content = existingPost.Content,
            UserId = existingPost.UserId,
            CreatedAt = existingPost.CreatedAt,
            LikeCount = likeCount,
            CommentCount = commentCount
        };
    }

    public async Task<bool> DeletePost(int postId, int userId)
    {
        //checking if it exists
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }
        
        if (existingPost.UserId != userId)
        {
            throw new Exception("You are not the owner of this post. you do not have permission to delete this post");
        }
        
        //removing from the DB
        _context.Posts.Remove(existingPost);
        await _context.SaveChangesAsync();
        
        //returning true
        return true;
    }

    public async Task<PostResponse> UpdatePost(int postId, string content, int userId)
    {
        //checking if it exists
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }

        if (existingPost.UserId != userId)
        {
            throw new Exception("You are not the owner of this post. you do not have permission to edit this post");
        }
        
        //getting the like and comment count
        var likeCount = await _context.Likes.CountAsync(l => l.PostId == postId);
        var commentCount = await _context.Comments.CountAsync(c => c.PostId == postId);
        
        //updating the post
        existingPost.Content = content;
        await _context.SaveChangesAsync();
        
        //returning the updated post
        return new PostResponse
        {
            Id = existingPost.Id,
            Content = existingPost.Content,
            UserId = existingPost.UserId,
            CreatedAt = existingPost.CreatedAt,
            LikeCount = likeCount,
            CommentCount = commentCount
        };
    }
}