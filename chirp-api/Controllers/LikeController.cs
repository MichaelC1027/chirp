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
            var response = await _likeService.CreateLikeOnPost(request.PostId, request.UserId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost]
    [Route ("CreateLikeOnComment")]
    public async Task<IActionResult> CreateLikeOnComment([FromBody] CreateLikeRequest request)
    {
        try
        {
            var response = await _likeService.CreateLikeOnComment(request.CommentId, request.UserId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete]
    [Route ("DeleteLikeOnPost")]
    public async Task<IActionResult> DeleteLikeOnPost([FromBody] DeleteLikeRequest request)
    {
        try
        {
            var response = await _likeService.DeleteLikeOnPost(request.PostId, request.UserId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route ("DeleteLikeOnComment")]
    public async Task<IActionResult> DeleteLikeOnComment([FromBody] DeleteLikeRequest request)
    {
        try
        {
            var response = await _likeService.DeleteLikeOnComment(request.CommentId, request.UserId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route ("GetLikes/{postId}")]
    public async Task<IActionResult> GetLikes([FromRoute] int postId)
    {
        try
        {
            var response = await _likeService.GetLikes(postId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}