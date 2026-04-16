namespace chirp_api.DTOs.Requests.Comment;

public class UpdateCommentRequest
{
    public int Id { get; set; }
    public required string Content { get; set; }
}