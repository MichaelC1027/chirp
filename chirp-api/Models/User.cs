namespace chirp_api.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsVerified { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBanned { get; set; }
}