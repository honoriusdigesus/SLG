using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class CostCenterException : System.Exception
    {
        public CostCenterException(string message) : base(message)
        {
        }
    }
}