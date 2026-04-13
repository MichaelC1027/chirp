namespace chirp_api.DTOs.Responses;

public class LikeResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
}