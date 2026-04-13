using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Comment;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    
    [HttpPost]
    [Route ("CreateComment")]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
    {
        try
        {
            var response = await _commentService.CreateComment(request.PostId, request.Content);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    [Route ("GetComments")]
    public async Task<IActionResult> GetCommentsByPost([FromQuery] int postId)
    {
        try
        {
            var response = await _commentService.GetCommentsByPost(postId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpDelete]
    [Route ("DeleteComment")]
    public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentRequest request)
    {
        try
        {
            var response = await _commentService.DeleteComment(request.Id);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPut]
    [Route ("UpdateComment")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentRequest request)
    {
        try
        {
            var response = await _commentService.UpdateComment(request.Id, request.Content);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("GetComment/{commentId}")]
    public async Task<IActionResult> GetComment([FromRoute] int commentId)
    {
        try
        {
            var response = await _commentService.GetComment(commentId);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}