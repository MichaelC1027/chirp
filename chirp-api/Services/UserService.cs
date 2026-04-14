using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;

namespace chirp_api.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserResponse>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> GetUserById(int userId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<UserResponse> GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> UpdateUser(int userid, string username, string email, string password, string bio, string profilePicture)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteUser(int userId)
    {
        throw new NotImplementedException();
    }
}