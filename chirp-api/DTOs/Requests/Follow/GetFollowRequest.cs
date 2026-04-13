namespace chirp_api.DTOs.Requests.Follow;

public class GetFollowRequest
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}