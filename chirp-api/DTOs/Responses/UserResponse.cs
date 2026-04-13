namespace chirp_api.DTOs.Responses;

public class UserResponse
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVerified { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBanned { get; set; }
}