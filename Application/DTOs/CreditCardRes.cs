using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreditCardRes
    {
        public int CreditcardId { get; set; }
        public string? Cardnumber { get; set; }
        public string? Cardtype { get; set; }
        public int? EmployeeId { get; set; }
    }
}
