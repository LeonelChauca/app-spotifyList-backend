using System;

namespace app_bk_spotifyList.Services.IServices;

public interface ISpotifyService
{
    Task<string> GetSpotifyAsync(string apikey, string spotifyUrl);
    Task GenerateAccessTokenAsync();

}
