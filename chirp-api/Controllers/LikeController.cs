using System.Security.Claims;
using chirp_api.DTOs.Requests.Like;
using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
[Authorize]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }
    
    [HttpPost]
    [Route ("CreateLikeOnPost")]
    public async Task<IActionResult> CreateLike([FromBody] CreateLikeRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _likeService.CreateLikeOnPost(request.PostId, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route ("CreateLikeOnComment")]
    public async Task<IActionResult> CreateLikeOnComment([FromBody] CreateLikeRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _likeService.CreateLikeOnComment(request.CommentId, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Route ("DeleteLikeOnPost")]
    public async Task<IActionResult> DeleteLikeOnPost([FromBody] DeleteLikeRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _likeService.DeleteLikeOnPost(request.PostId, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route ("DeleteLikeOnComment")]
    public async Task<IActionResult> DeleteLikeOnComment([FromBody] DeleteLikeRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _likeService.DeleteLikeOnComment(request.CommentId, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route ("GetLikesOnPosts/{postId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetLikesOnPost([FromRoute] int postId)
    {
        try
        {
            var response = await _likeService.GetLikesOnPosts(postId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("GetLikesOnComments/{commentId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetLikesOnComment([FromRoute] int commentId)
    {
        try
        {
            var response = await _likeService.GetLikesOnComments(commentId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}