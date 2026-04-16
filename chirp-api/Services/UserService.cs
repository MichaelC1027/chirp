using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

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
        var users = await _context.Users.OrderBy(u => u.CreatedAt).ToListAsync();
        return users.Select(u => new UserResponse
        {
            Id = u.Id,
            Username = u.Username,
            Email = "",
            Bio = u.Bio,
            ProfilePicture = u.ProfilePicture,
            CreatedAt = u.CreatedAt,
            IsVerified = u.IsVerified,
            IsAdmin = u.IsAdmin,
            IsBanned = u.IsBanned
            
        });
    }

    public async Task<UserResponse> GetUserById(int userId)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (existingUser == null)
        {
            throw new Exception("user not found");
        }

        return new UserResponse
        {
            Id = existingUser.Id,
            Username = existingUser.Username,
            Email = "",
            Bio = existingUser.Bio,
            ProfilePicture = existingUser.ProfilePicture,
            CreatedAt = existingUser.CreatedAt,
            IsVerified = existingUser.IsVerified,
            IsAdmin = existingUser.IsAdmin,
            IsBanned = existingUser.IsBanned
        };

    }
    
    public async Task<UserResponse> GetUserByUsername(string username)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (existingUser == null)
        {
            throw new Exception("user not found");
        }

        return new UserResponse
        {
            Id = existingUser.Id,
            Username = existingUser.Username,
            Email = "",
            Bio = existingUser.Bio,
            ProfilePicture = existingUser.ProfilePicture,
            CreatedAt = existingUser.CreatedAt,
            IsVerified = existingUser.IsVerified,
            IsAdmin = existingUser.IsAdmin,
            IsBanned = existingUser.IsBanned
        };
    }

    public async Task<UserResponse> UpdateUser(int userId, string? username, string? email, string? password, string? bio, string? profilePicture)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (existingUser == null)
        {
            throw new Exception("user not found");
        }
        
        //checking what is filled and what is null
        if(username != null)
        {
            var takenUsername = await _context.Users.AnyAsync(u => u.Username == username && u.Id != userId);
            if(takenUsername) { throw new Exception("username already taken"); }
            existingUser.Username = username;
        }
        if(email != null)
        {
            var takenEmail = await _context.Users.AnyAsync(u => u.Email == email && u.Id != userId);
            if(takenEmail) { throw new Exception("email already taken"); }
            existingUser.Email = email;
        }
        if(password != null)
        {
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }
        if(bio != null)
        {
            existingUser.Bio = bio;
        }
        if(profilePicture != null)
        {
            existingUser.ProfilePicture = profilePicture;
        }
        
        await _context.SaveChangesAsync();
        return new UserResponse
        {
            Id = existingUser.Id,
            Username = existingUser.Username,
            Email = existingUser.Email,
            Bio = existingUser.Bio,
            ProfilePicture = existingUser.ProfilePicture,
            CreatedAt = existingUser.CreatedAt,
            IsVerified = existingUser.IsVerified,
            IsAdmin = existingUser.IsAdmin,
            IsBanned = existingUser.IsBanned
        };
    }

    public async Task<bool> DeleteUser(int userId)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (existingUser == null)
        {
            throw new Exception("user not found");
        }
        
        _context.Users.Remove(existingUser);
        await _context.SaveChangesAsync();
        return true;
    }
}