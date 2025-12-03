using System;
using app_bk_spotifyList.Services.IServices;

namespace app_bk_spotifyList.Services.BackgroundServices;

public class SpotifyTokenInitializer:IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<SpotifyTokenInitializer> _logger;

    public SpotifyTokenInitializer(
        IServiceProvider serviceProvider, 
        ILogger<SpotifyTokenInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var spotifyService = scope.ServiceProvider.GetRequiredService<ISpotifyService>();
            
            // Forzar la generación del token
            await ((SpotifyService)spotifyService).GenerateAccessTokenAsync();
            
            _logger.LogInformation("Token de Spotify inicializado correctamente");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al inicializar token de Spotify");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

}
