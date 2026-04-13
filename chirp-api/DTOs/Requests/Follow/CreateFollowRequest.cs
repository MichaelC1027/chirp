namespace chirp_api.DTOs.Requests.Follow;

public class CreateFollowRequest
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}