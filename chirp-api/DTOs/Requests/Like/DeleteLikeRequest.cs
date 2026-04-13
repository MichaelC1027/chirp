namespace chirp_api.DTOs.Requests.Like;

public class DeleteLikeRequest
{
    public int UserId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
}