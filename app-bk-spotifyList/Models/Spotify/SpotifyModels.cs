using System;

namespace app_bk_spotifyList.Models.Spotify;


public class SpotifySearchWrapper
{
    public SpotifySearchResponse<SpotifyArtist> artists { get; set; } = new();
}
public class SpotifyTokenResponse
{
    public string access_token { get; set; } = string.Empty;
    public string token_type { get; set; } = string.Empty;
    public int expires_in { get; set; }
}
public class SpotifySearchResponse<T>
{
    public string href { get; set; } = string.Empty;
    public int limit { get; set; }
    public string? next { get; set; }
    public int offset { get; set; }
    public string? previous { get; set; }
    public int total { get; set; }
    public List<T> items { get; set; } = new();
}

public class SpotifyArtist
{
    public SpotifyExternalUrls external_urls { get; set; } = new();
    public SpotifyFollowers followers { get; set; } = new();
    public List<string> genres { get; set; } = new();
    public string href { get; set; } = string.Empty;
    public string id { get; set; } = string.Empty;
    public List<SpotifyImage> images { get; set; } = new();
    public string name { get; set; } = string.Empty;
    public int popularity { get; set; }
    public string type { get; set; } = string.Empty;
    public string uri { get; set; } = string.Empty;
}

public class SpotifyExternalUrls
{
    public string spotify { get; set; } = string.Empty;
}

public class SpotifyFollowers
{
    public string? href { get; set; }
    public int total { get; set; }
}

public class SpotifyImage
{
    public string url { get; set; } = string.Empty;
    public int height { get; set; }
    public int width { get; set; }
}
