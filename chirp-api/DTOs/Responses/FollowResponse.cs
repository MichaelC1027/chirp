namespace chirp_api.DTOs.Responses;

public class FollowResponse
{
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string ProfilePicture { get; set; }
}