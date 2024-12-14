using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class TokenReq
    {
        public string Token1 { get; set; } = null!;

        public DateTime Expires { get; set; }

        public DateTime Created { get; set; }

        public DateTime Revoked { get; set; }

        public int EmployeeId { get; set; }
    }
}
