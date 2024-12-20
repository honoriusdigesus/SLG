﻿
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITokenRepository
    {
        Task<Login> CreateAsync(Login token);
        Task<Login> GetByRefreshToken(string token);
    }
}
