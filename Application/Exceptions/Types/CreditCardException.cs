using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class CredirCardException : System.Exception
    {
        public CredirCardException(string message) : base(message)
        {
        }
    }
}