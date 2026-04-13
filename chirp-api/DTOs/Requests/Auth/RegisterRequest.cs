namespace chirp_api.DTOs.Requests.Auth;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}