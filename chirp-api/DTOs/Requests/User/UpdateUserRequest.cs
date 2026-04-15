namespace chirp_api.DTOs.Requests.User;

public class UpdateUserRequest
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePicture { get; set; }
}