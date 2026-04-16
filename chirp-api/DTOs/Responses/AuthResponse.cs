namespace chirp_api.DTOs.Responses;

public class AuthResponse
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
}