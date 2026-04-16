namespace chirp_api.DTOs.Requests.Comment;

public class CreateCommentRequest
{
    public required string Content { get; set; }
    public int PostId { get; set; }
}