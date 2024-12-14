using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
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
    }
}
