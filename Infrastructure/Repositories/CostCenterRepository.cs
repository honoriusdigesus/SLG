﻿using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
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
            //Save the Costcenter to the database or throw an exception if the Costcenter not saved
            var createdCostcenter = await _context.Costcenters.AddAsync(costcenter);
            if (createdCostcenter == null)
            {
                throw new CostCenterException("Costcenter not saved");
            }
            await _context.SaveChangesAsync();
            return createdCostcenter.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var costcenter = await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
            if (costcenter == null)
            {
                throw new CostCenterException("Costcenter not found");
            }
            _context.Costcenters.Remove(costcenter);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Costcenter>> GetAllAsync()
        {
            return await _context.Costcenters.ToListAsync();
        }

        public async Task<Costcenter> GetByIdAsync(int id)
        {
            var costcenter = await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
            if (costcenter == null)
            {
                throw new CostCenterException("Costcenter not found");
            }
            return costcenter;
        }

        public async Task<int> UpdateAsync(int id, Costcenter costcenter)
        {
            var costcenterToUpdate = await _context.Costcenters.FirstOrDefaultAsync(x => x.CostcenterId == id);
            if (costcenterToUpdate == null)
            {
                throw new CostCenterException("Costcenter not found");
            }
            costcenterToUpdate.Costcenternumber = costcenter.Costcenternumber;
            costcenterToUpdate.Description = costcenter.Description;
            costcenterToUpdate.ProjectmanagerId = costcenter.ProjectmanagerId;
            return await _context.SaveChangesAsync();
        }
    }
}
