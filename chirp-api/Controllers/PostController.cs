using Microsoft.AspNetCore.Mvc;
using chirp_api.Models;
//using chirp_api.Services;

namespace chirp_api.Controllers;

[Route ("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    [HttpPost]
    [Route ("CreateTwet/{postId}/{content}")]
    public IActionResult CreateTweet(int postId, string content)
    {
        return Ok();
    }
    
    [HttpGet]
    [Route ("GetTweets")]
    public IActionResult GetTweets()
    {
        return Ok();
    }

    [HttpGet]
    [Route("GetTweet/{postId}")]
    public IActionResult GetTweet(int postId)
    {
        return Ok();
    }
    
    [HttpDelete]
    [Route("DeleteTweet/{postId}")]
    public IActionResult DeleteTweet(int postId)
    {
        return Ok();
    }
    
    [HttpPut]
    [Route("UpdateTweet/{postId}/{content}")]
    public IActionResult UpdateTweet(int postId, string content)
    {
        return Ok();
    }
    
    
}