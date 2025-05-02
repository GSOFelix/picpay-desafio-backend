using Aplicacao.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra.Ext.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandlerExceptionAsync(context, ex);
            }
        }


        private static Task HandlerExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = exception switch
            {
                ArgumentException =>
                HttpStatusCode.BadRequest,

                KeyNotFoundException =>
                HttpStatusCode.NotFound,

                UnauthorizedAccessException =>
                HttpStatusCode.Forbidden,

                InvalidOperationException =>
                HttpStatusCode.BadRequest,

                _ =>
                HttpStatusCode.InternalServerError
            };

            var response = new ErrorResponse
            {
                StatusCode = (int)statusCode,
                Message = exception.Message,
                Details = exception.InnerException != null
                ? exception.InnerException.Message : "",
                Path = context.Request.Path
            };

            var json = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(json);

        }
    }
}
