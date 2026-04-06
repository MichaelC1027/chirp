using Microsoft.AspNetCore.Mvc;
using chirp_api.Models;
//using chirp_api.Services;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    public IActionResult CreateUser(int userId, string username,string email)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult LoginUser(string username, string password)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetUser(string username)
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateUser(string username, string password, string email)
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteUser(string username, string password)
    {
        return Ok();
    }
}