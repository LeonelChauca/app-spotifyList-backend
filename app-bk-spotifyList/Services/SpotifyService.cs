using System;
using System.Net.Http.Headers;
using System.Text.Json;
using app_bk_spotifyList.Models.Spotify;
using app_bk_spotifyList.Services.IServices;

namespace app_bk_spotifyList.Services;

public class SpotifyService : ISpotifyService
{
    public readonly IConfiguration _configuration;
    private string _accessToken = string.Empty;
    private DateTime _expiresAt=DateTime.MinValue;
    private string apiLoginUrl="https://accounts.spotify.com/api";
    private string apiBaseUrl="https://api.spotify.com/v1";
    private readonly IHttpClientFactory _httpClientFactory;

    public SpotifyService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }
    Task<string> ISpotifyService.GetSpotifyAsync(string apikey, string spotifyUrl)
    {
        throw new NotImplementedException();
    }

    public async Task GenerateAccessTokenAsync()
    {
        string clientId = Environment.GetEnvironmentVariable("CLIENT_SPOTIFY_ID")!;
        string clientSecret= Environment.GetEnvironmentVariable("CLIENT_SPOTIFY_SECRET")!;

        var client = _httpClientFactory.CreateClient();

        var requestBody = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_id", clientId },
            { "client_secret", clientSecret }
        });

        var response= await client.PostAsync($"{apiLoginUrl}/token", requestBody);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error de Spotify: {error}");
            throw new Exception("Error al acceder a la API de Spotify");
        }

        var content = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<SpotifyTokenResponse>(content);

        if (tokenResponse == null)
        {
            throw new Exception("Respuesta de token inválida de Spotify");
        }

        _accessToken = tokenResponse.access_token;
        _expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.expires_in);
        Console.WriteLine("Access token generado correctamente.");        
    }
    public async Task<SpotifySearchResponse<SpotifyArtist>> SearchArtistAsync(string artistName)
    {
        string requestUrl= $"{apiBaseUrl}/search?q={Uri.EscapeDataString(artistName)}&type=artist&limit=1";
        var client= _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization= new AuthenticationHeaderValue("Bearer", _accessToken);

        var response = await client.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error buscando artista: {response.StatusCode} - {error}");
        }

        var json= await response.Content.ReadAsStringAsync();
        var wrapper= JsonSerializer.Deserialize<SpotifySearchWrapper>(json);

        return wrapper!.artists;
    }    
}
