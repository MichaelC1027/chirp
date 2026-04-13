using Microsoft.AspNetCore.Mvc;
using chirp_api.Models;
//using chirp_api.Services;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("CreateUser/{userId}/{username}/{email}/{password}")]
    
    public IActionResult CreateUser(int userId, string username,string email, string password)
    {
        return Ok();
    }

    [HttpPost]
    [Route("LoginUser/{username}/{password}")]
    public IActionResult LoginUser(string username, string password)
    {
        return Ok();
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