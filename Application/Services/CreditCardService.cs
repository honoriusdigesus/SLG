using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions.Types;
using Application.Mappers;
using Domain.Interfaces;

namespace Application.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly CreditCardMapper _creditCardMapper;

        public CreditCardService(ICreditCardRepository creditCardRepository, CreditCardMapper creditCardMapper)
        {
            this._creditCardRepository = creditCardRepository;
            this._creditCardMapper = creditCardMapper;
        }
        public async Task<CreditCardRes> CreateAsync(CreditCardReq creditCard)
        {
            if (creditCard == null || creditCard.Cardnumber.Equals("") || creditCard.EmployeeId == null)
            {
                throw new CredirCardException("");
            }
            var creditCardEntity = _creditCardMapper.ToEntity(creditCard);
            var createdCreditCard = await _creditCardRepository.CreateAsync(creditCardEntity);
            return _creditCardMapper.ToResponse(createdCreditCard);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CreditCardRes>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CreditCardRes> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, CreditCardReq creditCard)
        {
            throw new NotImplementedException();
        }
    }
}
