using Microsoft.AspNetCore.Mvc;
using chirp_api.Services.Interfaces;
using chirp_api.DTOs.Requests.Auth;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }
    
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