using devtips_backend.Domain.Interfaces;
using devtips_backend.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace devtips_backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _authService.Register(request);
            return Created($"/user/{response.Id}", response);
        }
    }
}
