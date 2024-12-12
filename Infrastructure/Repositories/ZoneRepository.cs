using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Models;
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
            var createdZone = await _context.Zones.AddAsync(zone);
            if (createdZone == null)
            {
                throw new ZoneException("Zone not saved");
            }
            await _context.SaveChangesAsync();
            return createdZone.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var zone = await _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
            if (zone == null)
            {
                throw new ZoneException("Zone not found");
            }
            _context.Zones.Remove(zone);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Zone>> GetAllAsync()
        {
            return await _context.Zones.ToListAsync();
        }

        public async Task<Zone> GetByIdAsync(int id)
        {
            var zone = await _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
            if (zone == null)
            {
                throw new ZoneException("Zone not found");
            }
            return zone;
        }

        public async Task<int> UpdateAsync(int id, Zone zone)
        {
            var zoneToUpdate = await _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
            if(zoneToUpdate == null)
            {
                throw new ZoneException("Zone not found");
            }
            zoneToUpdate.Zonename = zone.Zonename;
            zoneToUpdate.Description = zone.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
