using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly SlgDbContext _context;

        public TokenRepository(SlgDbContext context)
        {
            _context = context;
        }
        public async Task<Login> CreateAsync(Login token)
        {
            if (token == null) {
                throw new ArgumentNullException("Token is null");
            }
            var createdToken = await _context.Logins.AddAsync(token);
            if (createdToken == null) {
                throw new TokenException("Token not saved");
            }
            await _context.SaveChangesAsync();
            return createdToken.Entity;
        }

        public async Task<Login> GetByRefreshToken(string token)
        {
            //Get by refreshToke
            var tokenEntity = await _context.Logins.FirstOrDefaultAsync(x => x.Refreshtoken == token);
            if (tokenEntity == null) {
                throw new TokenException("Token not found");
            }
            return tokenEntity;
        }
    }
}
