using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infrastructure.Entities;

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
            return await Task<Zone>.Run(() =>
            {
                _context.Zones.Add(zone);
                _context.SaveChanges();
                return zone;
            });
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Zone>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Zone> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Zone zone)
        {
            throw new NotImplementedException();
        }
    }
}
