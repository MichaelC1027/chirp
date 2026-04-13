using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface IAuthService
{ 
    Task<AuthResponse> CreateUser(string username, string email, string password);
    Task<AuthResponse> LoginUser(string username, string password);
}