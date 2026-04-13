namespace chirp_api.DTOs.Requests.Post;

public class GetPostRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
}