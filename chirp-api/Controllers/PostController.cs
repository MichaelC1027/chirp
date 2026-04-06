using Microsoft.AspNetCore.Mvc;

namespace chirp_api.Controllers;

public class PostController : Controller
{
    [HttpPost]
    public IActionResult CreateTweet(int postId, string content)
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetTweets()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetTweet(int postId)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteTweet(int postId)
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult UpdateTweet(int postId, string content)
    {
        return Ok();
    }
    
    
}