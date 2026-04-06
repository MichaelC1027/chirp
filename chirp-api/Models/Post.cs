namespace chirp_api.Models;

public class Post
{
    int Id { get; set; }
    string Content { get; set; }
    DateTime CreatedAt { get; set; }
    int UserId { get; set; }
    int LikeCount { get; set; }
    int CommentCount { get; set; }
    
}