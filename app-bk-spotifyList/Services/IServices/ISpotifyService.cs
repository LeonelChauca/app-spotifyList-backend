using System;
using app_bk_spotifyList.Models.Spotify;

namespace app_bk_spotifyList.Services.IServices;

public interface ISpotifyService
{
    Task<string> GetSpotifyAsync(string apikey, string spotifyUrl);
    Task GenerateAccessTokenAsync();

    Task<SpotifySearchResponse<SpotifyArtist>> SearchArtistAsync(string artistName);

}
