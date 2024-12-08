using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public interface IZoneServices
    {
        Task<List<ZoneRes>> GetAllAsync();
        Task<ZoneRes> GetByIdAsync(int id);
        Task<ZoneRes> CreateAsync(ZoneReq zone);
        Task<int> UpdateAsync(int id, ZoneReq zone);
        Task<int> DeleteAsync(int id);
    }
}
