namespace chirp_api.DTOs.Responses;

public class UserResponse
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Bio { get; set; }
    public required string ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVerified { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBanned { get; set; }
}