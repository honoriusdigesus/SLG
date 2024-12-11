using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions.Model;
using Application.Exceptions.Types;
using Microsoft.AspNetCore.Mvc;
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
                { typeof(EmployeeException), (HttpStatusCode.NotFound, new ErrorResponse("E101", "EMPLOYEE INVALID", null)) },
                { typeof(CostCenterException), (HttpStatusCode.NotFound, new ErrorResponse("CC101", "COST CENTER INVALID", null)) },
                { typeof(CredirCardException), (HttpStatusCode.NotFound, new ErrorResponse("TC101", "CREDIT CARD INVALID", null)) },
                { typeof(CategoryException), (HttpStatusCode.NotFound, new ErrorResponse("TC101", "CREDIT CARD INVALID", null)) },
        };
        }

        public override void OnException(ExceptionContext context)
        {
            if (_exceptionHandlers.TryGetValue(context.Exception.GetType(), out (HttpStatusCode StatusCode, ErrorResponse ErrorResponse) handler))
            {
                handler.ErrorResponse.Message = context.Exception.Message;
                context.HttpContext.Response.StatusCode = (int)handler.StatusCode;
                context.Result = new JsonResult(handler.ErrorResponse);
            }
            else
            {
                ErrorResponse genericErrorResponse = new ErrorResponse("ERROR DEFAULT", "Error handler", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new JsonResult(genericErrorResponse);
            }
            base.OnException(context);
        }

    }
}
