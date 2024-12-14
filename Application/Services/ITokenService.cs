using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface ITokenService
    {
        Task<TokenRes> CreateAsync(TokenReq token);
    }
}
