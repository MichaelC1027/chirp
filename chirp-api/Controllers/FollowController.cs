using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Follow;
using Microsoft.AspNetCore.Authorization;


namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
[Authorize]
public class FollowController :ControllerBase
{
    private readonly IFollowService _followService;

    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }
    
    [HttpPost]
    [Route ("CreateFollow")]
    public async Task<IActionResult> CreateFollow([FromBody] CreateFollowRequest request)
    {
        try
        {
            var response = await _followService.CreateFollow(request.FollowerId,request.FollowingId);
            return Ok(response);
        }catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route ("GetFollowers/{userId}")]
    public async Task<IActionResult> GetFollowers([FromRoute] int userId)
    {
        try
        {
            var response = await _followService.GetFollowers(userId);
            return Ok(response);
        }catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route ("GetFollowing/{userId}")]
    public async Task<IActionResult> GetFollowing([FromRoute] int userId)
    {
        try
        {
            var response = await _followService.GetFollowing(userId);
            return Ok(response);
        }catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route ("DeleteFollow")]
    public async Task<IActionResult> DeleteFollow([FromBody] DeleteFollowRequest request)
    {
        try
        {
            var response = await _followService.DeleteFollow(request.FollowerId,request.FollowingId);
            return Ok(response);
        }catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}