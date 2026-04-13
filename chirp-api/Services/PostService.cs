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

}