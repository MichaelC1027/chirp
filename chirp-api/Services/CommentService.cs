using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class CommentService : ICommentService
{
    private readonly AppDbContext _context;

    public CommentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CommentResponse> CreateComment(int postId, string content)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteComment(int commentId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsByPost(int postId)
    {
        throw new NotImplementedException();
    }

    public async Task<CommentResponse> UpdateComment(int commentId, string content)
    {
        throw new NotImplementedException();
    }

    public async Task<CommentResponse> GetComment(int commentId)
    {
        throw new NotImplementedException();
    }
}