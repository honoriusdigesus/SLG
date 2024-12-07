using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    internal class ZoneException : System.Exception
    {
        public ZoneException(string message) : base(message)
        {
        }
    }
}