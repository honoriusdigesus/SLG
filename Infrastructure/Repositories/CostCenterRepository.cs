using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Models;

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

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Costcenter>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Costcenter> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Costcenter costcenter)
        {
            throw new NotImplementedException();
        }
    }
}
