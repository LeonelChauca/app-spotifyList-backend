using app_bk_spotifyList.Models;
using app_bk_spotifyList.Models.Dtos.RefreshToken;
using app_bk_spotifyList.Repository.IRepository;
using app_bk_spotifyList.Services.IServices;
using AutoMapper;

namespace app_bk_spotifyList.Services;

public class RefreshTokenService:IRefreshTokenService
{

    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IMapper _mapper;
    
    public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IMapper mapper   )
    {
        _refreshTokenRepository = refreshTokenRepository;
        _mapper = mapper;
    }

    async Task<bool> IRefreshTokenService.CreateRefreshToken(CreateRefreshTokenDto createRefreshTokenDto)
    {
        var refreshToken= _mapper.Map<RefreshToken>(createRefreshTokenDto);
        return await _refreshTokenRepository.CreateAsync(refreshToken);
    }

    Task<string> IRefreshTokenService.GetRefreshToken(int token)
    {
        throw new NotImplementedException();
    }

    async Task<bool> IRefreshTokenService.InvalidateRefreshToken(string token)
    {
        var refreshToken= await _refreshTokenRepository.GetByTokenAsync(token);
        if(refreshToken==null)
        {
            throw new Exception("El token no existe");
        }
        return await _refreshTokenRepository.UpdateIsActiveAsync(refreshToken.id_refresh_token, false);
    }
}
