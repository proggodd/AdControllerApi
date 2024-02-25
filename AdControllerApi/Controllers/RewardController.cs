using Microsoft.AspNetCore.Mvc;
using MyAdsApi.Models;

namespace MyAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly UserService _userService;

        public RewardsController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("users/{userId}/rewards")]
        public IActionResult GetUserRewards(int userId)
        {
            List<Reward> rewards = _userService.GetUserRewards(userId);
            return Ok(rewards);
        }

        [HttpPost("users/{userId}/rewards/claim")]
        public IActionResult ClaimReward(int userId, [FromBody] RewardClaimRequest request)
        {
            _userService.ClaimReward(userId, request);
            return Ok();
        }

        // Other actions related to reward management can be added here
    }
}
