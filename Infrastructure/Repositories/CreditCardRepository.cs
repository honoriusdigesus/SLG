﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Models;

namespace Infrastructure.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly SlgDbContext _context;

        public CreditCardRepository(SlgDbContext context)
        {
            _context = context;
        }

        public async Task<Creditcard> CreateAsync(Creditcard creditcard)
        {
            await _context.Creditcards.AddAsync(creditcard);
            await _context.SaveChangesAsync();
            return creditcard;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Creditcard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Creditcard> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Creditcard creditcard)
        {
            throw new NotImplementedException();
        }
    }
}