﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IZoneRepository
    {
        Task<List<Zone>> GetAllAsync();
        Task<Zone> GetByIdAsync(int id);
        Task<Zone> CreateAsync(Zone zone);
        Task<int> UpdateAsync(int id, Zone zone);
        Task<int> DeleteAsync(int id);
    }
}
