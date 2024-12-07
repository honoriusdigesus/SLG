using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly SlgDbContext _context;

        public ZoneRepository(SlgDbContext context)
        {
            _context = context;
        }

        public async Task<Zone> CreateAsync(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Zone>> GetAllAsync()
        {
            return await _context.Zones.ToListAsync();
        }

        public Task<Zone> GetByIdAsync(int id)
        {
            return _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
        }

        public Task<int> UpdateAsync(int id, Zone zone)
        {
            throw new NotImplementedException();
        }
    }
}
