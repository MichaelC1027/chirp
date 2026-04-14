using chirp_api.DTOs.Responses;

namespace chirp_api.Services.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponse>> GetUsers();
    Task<UserResponse> GetUserById(int userId);
    Task<UserResponse> GetUserByUsername(string username);
    Task<UserResponse> UpdateUser(int userid, string username, string email, string password, string bio, string profilePicture);
    Task<bool> DeleteUser(int userId);
}