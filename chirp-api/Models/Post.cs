namespace chirp_api.Models;

public class Post
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    
}