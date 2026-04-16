using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Post;
using Microsoft.AspNetCore.Authorization;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
[Authorize]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    [HttpPost]
    [Route ("CreatePost")]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _postService.CreatePost(request.Content,userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route ("GetPosts")]
    [AllowAnonymous]
    public async Task<IActionResult>  GetPosts()
    {
        try
        {
            var response = await _postService.GetPosts();
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("GetPost/{postId}")]
    [AllowAnonymous]
    public async Task<IActionResult>  GetPost([FromRoute] int postId)
    {
        try
        {
            var response = await _postService.GetPost(postId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("DeletePost")]
    public async Task<IActionResult>  DeletePost([FromBody] DeletePostRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _postService.DeletePost(request.Id, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    [Route("UpdatePost")]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var response = await _postService.UpdatePost(request.Id, request.Content, userId);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}