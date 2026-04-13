using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AuthResponse> CreateUser(string username, string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<AuthResponse> LoginUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}