using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.Model
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Error { get; set; }
        public string? Message { get; set; }

        public ErrorResponse(string code, string error, string? message)
        {
            Code = code;
            Error = error;
            Message = message;
        }
    }
}
