using Microsoft.AspNetCore.Mvc;

namespace chirp_api.Controllers;

[ApiController]
public class LikeController : Controller
{
    [HttpPost]
    public IActionResult CreateLike(int postId)
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteLike(int postId)
    {
        return Ok();
    }
    [HttpGet]
    public IActionResult GetLikes(int postId)
    {
        return Ok();
    }
}