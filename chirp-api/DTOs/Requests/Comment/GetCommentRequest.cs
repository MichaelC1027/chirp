namespace chirp_api.DTOs.Requests.Comment;

public class GetCommentRequest
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
}