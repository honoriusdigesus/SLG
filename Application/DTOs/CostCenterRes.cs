using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CostCenterRes
    {
        public int CostcenterId { get; set; }
        public int CostCenterNumber { get; set; }
        public string? Description { get; set; }
        public int ProjectManagerId { get; set; }
    }
}
