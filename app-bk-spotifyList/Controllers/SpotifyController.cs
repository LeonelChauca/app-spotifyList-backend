using app_bk_spotifyList.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app_bk_spotifyList.Controllers
{
    [Route("api/spotify")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> SearchArtist(string query)
        {
            var result = await _spotifyService.SearchArtistAsync(query);
            return Ok(result);
        }
    }
}
