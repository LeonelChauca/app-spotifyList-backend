using app_bk_spotifyList.Models.Dtos.auth;
using app_bk_spotifyList.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app_bk_spotifyList.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Login([FromBody] AuthDto authDto)
        {
            var result = await _authService.login(authDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }


    }
}
