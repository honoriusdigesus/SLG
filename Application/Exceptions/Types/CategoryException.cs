using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Types
{
    public class CategoryException : System.Exception
    {
        public CategoryException(string message) : base(message)
        {
        }
    }
}