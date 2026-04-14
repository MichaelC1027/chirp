using chirp_api.Data;
using chirp_api.DTOs.Responses;
using chirp_api.Models;
using chirp_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace chirp_api.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<AuthResponse> CreateUser(string username, string email, string password)
    {
        var existingUsername = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (existingUsername != null)
        {
            throw new Exception("Username already taken");
        }
        
        var existingEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (existingEmail != null)
        {
            throw new Exception("An Account with that email already exists");
        }

        var user = new User
        {
            Username = username,
            Email = email,
            Password = BCrypt.Net.BCrypt.HashPassword(password),
            CreatedAt = DateTime.UtcNow,
            Bio = "Edit me!",
            ProfilePicture = "https://imgur.com/gallery/teacup-frog-EMYhrEM",
            IsVerified = false,
            IsAdmin = false,
            IsBanned = false
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            Username = user.Username,
            Email = user.Email,
            Token = GenerateJwtToken(user)
        };
    }

    public async Task<AuthResponse> LoginUser(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            throw new Exception("Invalid username or password");
        }

        return new AuthResponse
        {
            Username = user.Username,
            Email = user.Email,
            Token = GenerateJwtToken(user)
        };
    }

    private string GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };
        
        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(int.Parse(_configuration["JWT:ExpiresInDays"]!)),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}