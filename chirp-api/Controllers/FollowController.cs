using System.Security.Claims;
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
            var followerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _followService.CreateFollow(followerId, request.FollowingId);
            return Ok(response);
        }catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route ("GetFollowers/{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFollowers([FromRoute] int userId)
    {
        try
        { 
            var response = await _followService.GetFollowers(userId);
            return Ok(response);
        }catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route ("GetFollowing/{userId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFollowing([FromRoute] int userId)
    {
        try
        {
            var response = await _followService.GetFollowing(userId);
            return Ok(response);
        }catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete]
    [Route ("DeleteFollow")]
    public async Task<IActionResult> DeleteFollow([FromBody] DeleteFollowRequest request)
    {
        try
        {
            var followerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _followService.DeleteFollow(followerId, request.FollowingId);
            return Ok(response);
        }catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}