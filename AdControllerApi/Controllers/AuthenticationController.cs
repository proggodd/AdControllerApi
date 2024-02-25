using AdControllerApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using MyAdsApi.Models;
using MyAdsApi.Services;

namespace MyAdsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly JwtAuthenticationService _jwtAuthenticationService;

        public AuthenticationController(UserService userService, JwtAuthenticationService jwtAuthenticationService)
        {
            _userService = userService;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            // Check if the user already exists
            if (_userService.GetUserByEmail(user.Email) != null)
            {
                return Conflict("User with the provided email already exists.");
            }

            // Hash the user's password (You should never store passwords as plain text!)
            user.PasswordHash = PasswordHashingService.HashPassword(user.Password);

            // Save the user to the database
            _userService.CreateUser(user);

            // Return a success response
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto loginModel)
        {
            // Authenticate the user
            User authenticatedUser = _userService.AuthenticateUser(loginModel.Email, loginModel.Password);

            // Check if authentication failed
            if (authenticatedUser == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Generate JWT token
            string token = _jwtAuthenticationService.GenerateToken(authenticatedUser);

            // Return the token
            return Ok(new { Token = token });
        }
    }
}
