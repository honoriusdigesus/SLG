using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Services
{
    public interface ICreditCardService
    {
        Task<List<CreditCardRes>> GetAllAsync();
        Task<CreditCardRes> GetByIdAsync(int id);
        Task<CreditCardRes> CreateAsync(CreditCardReq creditCard);
        Task<int> UpdateAsync(int id, CreditCardReq creditCard);
        Task<int> DeleteAsync(int id);
    }
}
