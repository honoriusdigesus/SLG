using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly SlgDbContext _context;

        public CostCenterRepository(SlgDbContext context)
        {
            _context = context;
        }
        public async Task<Costcenter> CreateAsync(Costcenter costcenter)
        {
            await _context.Costcenters.AddAsync(costcenter);
            await _context.SaveChangesAsync();
            return costcenter;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var costcenter = await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
            _context.Costcenters.Remove(costcenter);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Costcenter>> GetAllAsync()
        {
            return await _context.Costcenters.ToListAsync();
        }

        public async Task<Costcenter> GetByIdAsync(int id)
        {
            return await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
        }

        public async Task<int> UpdateAsync(int id, Costcenter costcenter)
        {
            var costcenterToUpdate = await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
            if (costcenterToUpdate != null)
            {
                costcenterToUpdate.Costcenternumber = costcenter.Costcenternumber;
                costcenterToUpdate.Description = costcenter.Description;
                costcenterToUpdate.ProjectmanagerId = costcenter.ProjectmanagerId;                
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
