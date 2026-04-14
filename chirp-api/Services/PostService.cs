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
            CreatedAt = DateTime.UtcNow,
            LikeCount = 0,
            CommentCount = 0
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
            LikeCount = post.LikeCount,
            CommentCount = post.CommentCount
        };
    }

    public async Task<IEnumerable<PostResponse>> GetPosts()
    {
        var posts = await _context.Posts.OrderByDescending(p => p.CreatedAt).ToListAsync();
        return posts.Select(p => new PostResponse
        {
            Id = p.Id,
            Content = p.Content,
            UserId = p.UserId,
            CreatedAt = p.CreatedAt,
            LikeCount = p.LikeCount,
            CommentCount = p.CommentCount
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
        
        //returning the post by ID
        return new PostResponse
        {
            Id = existingPost.Id,
            Content = existingPost.Content,
            UserId = existingPost.UserId,
            CreatedAt = existingPost.CreatedAt,
            LikeCount = existingPost.LikeCount,
            CommentCount = existingPost.CommentCount
        };
    }

    public async Task<bool> DeletePost(int postId)
    {
        //checking if it exists
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }
        
        //removing from the DB
        _context.Posts.Remove(existingPost);
        await _context.SaveChangesAsync();
        
        //returning true
        return true;
    }

    public async Task<PostResponse> UpdatePost(int postId, string content)
    {
        //checking if it exists
        var existingPost = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);
        if (existingPost == null)
        {
            throw new Exception("Post not found");
        }
        
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
            LikeCount = existingPost.LikeCount,
            CommentCount = existingPost.CommentCount
        };
    }
}