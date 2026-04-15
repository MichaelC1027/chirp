namespace chirp_api.DTOs.Requests.Like;

public class CreateLikeRequest
{
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
}