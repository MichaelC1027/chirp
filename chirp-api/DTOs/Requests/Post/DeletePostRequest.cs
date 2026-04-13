namespace chirp_api.DTOs.Requests.Post;

public class DeletePostRequest
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
}