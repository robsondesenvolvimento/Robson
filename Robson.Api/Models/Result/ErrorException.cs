﻿using System;

namespace Robson.Api.Models.Result
{
    public class ErrorException
    {
        public int StatusCode { get; init; }
        public string StatusCodeDescription { get; init; }
        public string Menssage { get; init; }

        public static ErrorException From(Exception e, int statusCode, string statusCodeDescription)
        {
            if (e == null)
                return null;

            return new ErrorException
            {
                StatusCode = statusCode,//(int)HttpStatusCode.InternalServerError,
                StatusCodeDescription = statusCodeDescription, //HttpStatusCode.InternalServerError.ToString(),
                Menssage = e.Message
            };
        }
    }
}
