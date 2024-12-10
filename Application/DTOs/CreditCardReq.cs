using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreditCardReq
    {
        public string? Cardnumber { get; set; }
        public string? Cardtype { get; set; }
        public int? EmployeeId { get; set; }
    }
}
