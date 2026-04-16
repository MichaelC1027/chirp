namespace chirp_api.DTOs.Responses;

public class PostResponse
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int LikeCount { get; set; } 
    public int CommentCount { get; set; }
}