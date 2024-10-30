using Microsoft.AspNetCore.Mvc;
using BookShop.Application.Common;
using BookShop.Domain.Entities;

namespace BookShop.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginUser)
        {
            var user = await _authService.ValidateUserAsync(loginUser.Username, loginUser.PasswordHash);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
