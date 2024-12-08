﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var zone = await _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
            _context.Zones.Remove(zone);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Zone>> GetAllAsync()
        {
            return await _context.Zones.ToListAsync();
        }

        public Task<Zone> GetByIdAsync(int id)
        {
            return _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
        }

        public async Task<int> UpdateAsync(int id, Zone zone)
        {
            var zoneToUpdate = await _context.Zones.FirstOrDefaultAsync(x => x.ZoneId == id);
            zoneToUpdate.Zonename = zone.Zonename;
            zoneToUpdate.Description = zone.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
