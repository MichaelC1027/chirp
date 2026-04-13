using Microsoft.AspNetCore.Mvc;
using chirp_api.Models;
//using chirp_api.Services;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    [HttpPost]
    [Route ("CreateLike/{postId}")]
    public IActionResult CreateLike(int postId)
    {
        return Ok();
    }

    [HttpDelete]
    [Route ("DeleteLike/{postId}")]
    public IActionResult DeleteLike(int postId)
    {
        return Ok();
    }
    [HttpGet]
    [Route ("GetLikes/{postId}")]
    public IActionResult GetLikes(int postId)
    {
        return Ok();
    }
}