namespace chirp_api.DTOs.Requests.Post;

public class CreatePostRequest
{
    public string Content { get; set; }
    public int UserId { get; set; }
}