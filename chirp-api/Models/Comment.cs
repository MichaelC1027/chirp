namespace chirp_api.Models;

public class Comment
{
    int Id { get; set; }
    string Content { get; set; }
    DateTime CreatedAt { get; set; }
    int UserId { get; set; }
    int PostId { get; set; }
    int LikeCount { get; set; }
    int ReplyCount { get; set; }
}