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

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0) {
                throw new CredirCardException("CreditCard id is required");
            }
            return await _creditCardRepository.DeleteAsync(id);
        }

        public async Task<List<CreditCardRes>> GetAllAsync()
        {
            return (await _creditCardRepository.GetAllAsync()).Select(_creditCardMapper.ToResponse).ToList();
        }

        public async Task<CreditCardRes> GetByIdAsync(int id)
        {
            if (id < 1 || id==null) {
                throw new CredirCardException("CreditCard id is required");
            }
            var creditCard = await _creditCardRepository.GetByIdAsync(id);
            if (creditCard == null)
            {
                throw new CredirCardException("CreditCard not found");
            }
            return _creditCardMapper.ToResponse(creditCard);
        }

        public async Task<int> UpdateAsync(int id, CreditCardReq creditCard)
        {
           if (id <= 0 || creditCard == null || creditCard.Cardnumber.Equals("") || creditCard.EmployeeId == null)
            {
                //Verifica la información
                throw new CredirCardException("CreditCard id is required");
            }
            return await _creditCardRepository.UpdateAsync(id, _creditCardMapper.ToEntity(creditCard));
        }
    }
}
