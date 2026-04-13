using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Auth;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("GetUser/{username}")]
    public IActionResult GetUser(string username)
    {
        return Ok();
    }
    
    [HttpPut]
    [Route("UpdateUser/{username}/{password}/{email}")]
    public IActionResult UpdateUser(string username, string password, string email)
    {
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteUser/{username}/{password}")]
    public IActionResult DeleteUser(string username, string password)
    {
        return Ok();
    }
}