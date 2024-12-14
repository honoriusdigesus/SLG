using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions.Types;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly TokenMapper _tokenMapper;

        public TokenService(ITokenRepository tokenRepository, TokenMapper tokenMapper)
        {
            _tokenRepository = tokenRepository;
            _tokenMapper = tokenMapper;
        }
        public async Task<TokenRes> CreateAsync(TokenReq token)
        {
            var tokenEntity = _tokenMapper.ToEntity(token);
            var createdToken = await _tokenRepository.CreateAsync(tokenEntity);
            return _tokenMapper.ToResponse(createdToken);
        }

        public async Task<TokenRes> RefreshToken(string token)
        {
            // Verificar que el refresh token exista en la base de datos y que no esté revocado ni haya expirado
            var tokenEntity = await _tokenRepository.GetByRefreshToken(token);
            if (tokenEntity == null || tokenEntity.Expires < DateTime.Now || tokenEntity.Revoked != null)
            {
                throw new TokenException("Token no válido");
            }
            tokenEntity.Revoked = DateTime.Now;
            await _tokenRepository.CreateAsync(tokenEntity);
            return _tokenMapper.ToResponse(tokenEntity);
        }
    }
}
