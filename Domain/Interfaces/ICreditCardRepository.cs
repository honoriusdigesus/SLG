﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICreditCardRepository
    {
        Task<List<Creditcard>> GetAllAsync();
        Task<Creditcard> GetByIdAsync(int id);
        Task<Creditcard> CreateAsync(Creditcard creditcard);
        Task<int> UpdateAsync(int id, Creditcard creditcard);
        Task<int> DeleteAsync(int id);
    }
}
