using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Model;
using Application.Exceptions.Types;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Exceptions
{
    public class ErrorHandler : ExceptionFilterAttribute
    {
        private readonly Dictionary<Type, (HttpStatusCode StatusCode, ErrorResponse ErrorResponse)> _exceptionHandlers;

        public ErrorHandler()
        {
            _exceptionHandlers = new Dictionary<Type, (HttpStatusCode, ErrorResponse)>
        {
                { typeof(ZoneException), (HttpStatusCode.NotFound, new ErrorResponse("Z101", "ZONE INVALID", null)) },

        };
        }

    }
}
