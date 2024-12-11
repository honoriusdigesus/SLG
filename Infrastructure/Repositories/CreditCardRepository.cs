using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Types;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            //Save the Creditcard to the database or throw an exception if the Creditcard not saved
            var createdCreditcard = await _context.Creditcards.AddAsync(creditcard);
            if (createdCreditcard == null)
            {
                throw new CredirCardException("Creditcard not saved");
            }
            await _context.SaveChangesAsync();
            return createdCreditcard.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var creditcard = await _context.Creditcards.FirstAsync(x => x.CreditcardId == id);
            if (creditcard == null)
            {
                throw new CredirCardException("Creditcard not found");
            }
            _context.Creditcards.Remove(creditcard);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Creditcard>> GetAllAsync()
        {
            return await _context.Creditcards.ToListAsync();
        }

        public async Task<Creditcard> GetByIdAsync(int id)
        {
            var creditcard = await _context.Creditcards.FirstAsync(x => x.CreditcardId == id);
            if (creditcard == null)
            {
                throw new CredirCardException("Creditcard not found");
            }
            return creditcard;
        }

        public async Task<int> UpdateAsync(int id, Creditcard creditcard)
        {
            //Find by id and update the creditcard or throw an exception if the creditcard not updated
            var creditcardToUpdate = await _context.Creditcards.FirstOrDefaultAsync(x => x.CreditcardId == id);
            if (creditcardToUpdate == null)
            {
                throw new CredirCardException("Creditcard not found");
            }
            creditcardToUpdate.Cardnumber = creditcard.Cardnumber;
            creditcardToUpdate.EmployeeId = creditcard.EmployeeId;
            creditcardToUpdate.Cardtype = creditcard.Cardtype;
            return await _context.SaveChangesAsync();


        }
    }
}
