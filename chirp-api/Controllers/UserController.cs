using chirp_api.DTOs.Requests.User;
using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;


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
    [Route("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var response = await _userService.GetUsers();
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("GetUserByUsername/{username}")]
    public async Task<IActionResult> GetUserByUserName([FromRoute] string username)
    {
        try
        {
            var response = await _userService.GetUserByUsername(username);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route("GetUserById/{userId}")]
    public async Task<IActionResult> GetUserById([FromRoute] int userId)
    {
        try
        {
            var response = await _userService.GetUserById(userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut]
    [Route("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
    {
        try
        {
            var response = await _userService.UpdateUser(request.Id,request.Username, request.Email, request.Password, request.Bio, request.ProfilePicture);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
    {
        try
        {
            var response = await _userService.DeleteUser(request.Id);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}