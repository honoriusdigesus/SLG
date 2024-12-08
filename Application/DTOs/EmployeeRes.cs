using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmployeeRes
    {
        public int Id { get; set; }
        public string Document { get; set; } = null!;

        public string? Name { get; set; }

        public string? Lastname { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public string? Phone { get; set; }

        public int? ZoneId { get; set; }
    }
}
