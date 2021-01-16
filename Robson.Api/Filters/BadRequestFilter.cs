﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Robson.Api.Models.Result;
using System.Net;

namespace Robson.Api.Filters
{
    public class BadRequestFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ErrorException.From(context.Exception,
                    (int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString()))
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
