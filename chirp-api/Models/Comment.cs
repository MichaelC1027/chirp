namespace chirp_api.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
    public int LikeCount { get; set; }
    public int ReplyCount { get; set; }
}