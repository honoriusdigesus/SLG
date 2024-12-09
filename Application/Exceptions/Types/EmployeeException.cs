using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class EmployeeException : System.Exception
    {
        public EmployeeException(string message) : base(message)
        {
        }
    }
}