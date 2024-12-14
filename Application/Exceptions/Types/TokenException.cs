using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class TokenException : System.Exception
    {
        public TokenException(string message) : base(message)
        {
        }
    }
}