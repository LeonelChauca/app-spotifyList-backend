using System;
using app_bk_spotifyList.Services.IServices;

namespace app_bk_spotifyList.Services;

public class SpotifyService : ISpotifyService
{

    public readonly IConfiguration _configuration;
    private string _accessToken = string.Empty;

    private DateTime _expiresAt=DateTime.MinValue;

    public SpotifyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    Task<string> ISpotifyService.GetSpotifyAsync(string apikey, string spotifyUrl)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateAccessTokenAsync()
    {
        var jwt=_configuration.GetSection("Spotify");
        string clientId= _configuration.GetValue<string>("SpotifyApi:ClientId")!;
        string clientSecret= _configuration.GetValue<string>("SpotifyApi:ClientSecret")!;

        var client = new HttpClient();
        
    }
}
