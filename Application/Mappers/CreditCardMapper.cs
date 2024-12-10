using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class CreditCardMapper
    {
        //From CreditCardReq to CreditCard
        public Creditcard ToEntity(CreditCardReq creditCardReq)
        {
            return new Creditcard
            {
                Cardnumber = creditCardReq.Cardnumber,
                Cardtype = creditCardReq.Cardtype,
                EmployeeId = creditCardReq.EmployeeId
            };
        }

        //From CreditCard to CreditCardRes
        public CreditCardRes ToResponse(Creditcard creditCard)
        {
            return new CreditCardRes
            {
                CreditcardId = creditCard.CreditcardId,
                Cardnumber = creditCard.Cardnumber,
                Cardtype = creditCard.Cardtype,
                EmployeeId = creditCard.EmployeeId
            };
        }
    }
}
