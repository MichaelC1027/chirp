using Microsoft.AspNetCore.Mvc;
using chirp_api.Models;
//using chirp_api.Services;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    [HttpPost]
    [Route ("CreateComment/{postId}")]
    public IActionResult CreateComment(int postId)
    {
        return Ok();
    }
    
    [HttpGet]
    [Route ("GetComments")]
    public IActionResult GetCommentsByPost(int postId)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route ("DeleteComment/{commentId}")]
    public IActionResult DeleteComment(int commentId)
    {
        return Ok();
    }
    
    [HttpPut]
    [Route ("UpdateComment/{commentId}/{content}")]
    public IActionResult UpdateComment(int commentId, string content)
    {
        return Ok();
    }
}