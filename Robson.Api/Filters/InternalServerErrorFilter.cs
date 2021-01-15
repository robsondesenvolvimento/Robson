using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Robson.Api.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Robson.Api.Filters
{
    public class InternalServerErrorFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ErrorException.From(context.Exception, 
                (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString())) 
            { 
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
