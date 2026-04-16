namespace chirp_api.DTOs.Requests.Post;

public class UpdatePostRequest
{
    public required string Content { get; set; }
    public int Id { get; set; }
}