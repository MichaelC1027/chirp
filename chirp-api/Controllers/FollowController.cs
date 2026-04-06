using Microsoft.AspNetCore.Mvc;

namespace chirp_api.Controllers;

public class FollowController :Controller
{
    [HttpPost]
    public IActionResult CreateFollow(int userId, int followerId)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetFollowers(int userId)
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetFollowing(int userId)
    {
        return Ok();
    }
    
    [HttpDelete]
    public IActionResult DeleteFollow(int userId, int followerId)
    {
        return Ok();
    }
}