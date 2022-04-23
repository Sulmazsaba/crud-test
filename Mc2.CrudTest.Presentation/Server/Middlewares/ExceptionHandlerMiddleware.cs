﻿using Mc2.CrudTest.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await SetFaultResponse(context, ex);
            }
        }

        private async Task SetFaultResponse(object context, Exception ex)
        {
            if (context is HttpContext httpContext)
            {
                var error = ex.Message;
                var statusCode = GetStatusCode(ex);

                httpContext.Response.Clear();
                httpContext.Response.StatusCode = statusCode;
                httpContext.Response.ContentType = "application/json";

                var response = new Response { Text = error };
                var responseContent = JsonConvert.SerializeObject(response);
                await httpContext.Response.WriteAsync(responseContent);
            }
        }

        private int GetStatusCode(Exception ex)
        {
            if (ex is ArgumentNullException)
            {
                return StatusCodes.Status404NotFound;
            }
            if (ex is DomainException)
            {
                return StatusCodes.Status400BadRequest;
            }

            return StatusCodes.Status500InternalServerError;
        }
    }

    public class Response
    {
        public string Text { get; set; }
    }
}
