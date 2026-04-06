using Microsoft.AspNetCore.Mvc;

namespace chirp_api.Controllers;

public class CommentController : Controller
{
    [HttpPost]
    public IActionResult CreateComment(int postId)
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetCommentsByPost(int postId)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteComment(int commentId)
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateComment(int commentId, string content)
    {
        return Ok();
    }
}