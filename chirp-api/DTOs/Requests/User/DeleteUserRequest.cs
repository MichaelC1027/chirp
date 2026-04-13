namespace chirp_api.DTOs.Requests.User;

public class DeleteUserRequest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}