namespace chirp_api.DTOs.Responses;

public class FollowResponse
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}