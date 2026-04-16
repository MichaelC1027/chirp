using System.Security.Claims;
using chirp_api.DTOs.Requests.User;
using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("GetUsers")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("GetUserByUsername/{username}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserByUserName([FromRoute] string username)
    {
        try
        {
            var response = await _userService.GetUserByUsername(username);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet]
    [Route("GetUserById/{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        try
        {
            var response = await _userService.GetUserById(userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _userService.UpdateUser(userId, request.Username, request.Email, request.Password, request.Bio, request.ProfilePicture);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser()
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _userService.DeleteUser(userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}