using app_bk_spotifyList.Models.Dtos;
using app_bk_spotifyList.Services;
using app_bk_spotifyList.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace app_bk_spotifyList.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var users= await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var result= await _userService.CreateUserAsync(createUserDto);
            if(!result)
            {
                return BadRequest("No se pudo crear el usuario");
            }
            return Ok();
        }
    }
}
