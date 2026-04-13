using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Auth;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    [Route("CreateUser/")]
    
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequest registerRequest)
    {
        try
        {
            var response = await _authService.CreateUser(registerRequest.Username, registerRequest.Email, registerRequest.Password);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPost]
    [Route("LoginUser/")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest loginRequest)
    {
        try
        {
            var response = await _authService.LoginUser(loginRequest.Username, loginRequest.Password);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}