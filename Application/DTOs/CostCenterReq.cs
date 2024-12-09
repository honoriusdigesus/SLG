using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CostCenterReq
    {
        public int Costcenternumber { get; set; }
        public string? Description { get; set; }
        public int ProjectmanagerId { get; set; }
    }
}
