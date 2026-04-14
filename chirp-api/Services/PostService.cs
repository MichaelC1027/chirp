using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    
    public PostService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PostResponse> CreatePost(string content)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PostResponse>> GetPosts()
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse> GetPost(int postId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeletePost(int postId)
    {
        throw new NotImplementedException();
    }

    public async Task<PostResponse> UpdatePost(int postId, string content)
    {
        throw new NotImplementedException();
    }
}