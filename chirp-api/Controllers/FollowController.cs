using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Auth;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class FollowController :ControllerBase
{
    private readonly IFollowService _followService;

    public FollowController(IFollowService followService)
    {
        _followService = followService;
    }
    
    [HttpPost]
    [Route ("CreateFollow")]
    public IActionResult CreateFollow(int userId, int followerId)
    {
        return Ok();
    }

    [HttpGet]
    [Route ("GetFollowers/{userId}")]
    public IActionResult GetFollowers(int userId)
    {
        return Ok();
    }

    [HttpGet]
    [Route ("GetFollowing/{userId}")]
    public IActionResult GetFollowing(int userId)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route ("DeleteFollow/{userId}/{followerId}")]
    public IActionResult DeleteFollow(int userId, int followerId)
    {
        return Ok();
    }
}