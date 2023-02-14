using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bravi.Application.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DbUpdateException ex)
            {
                HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async void HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //exception.Ship(context);
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var x = new {
                    Erro = exception.InnerException?.Message.ToString() ?? string.Empty,
                };

                var jsonObject = JsonSerializer.Serialize(x);
                await context.Response.WriteAsync(jsonObject, Encoding.UTF8);

                await responseBody.CopyToAsync(originalBodyStream); //IMPORTANT!
                return;
            }


        }
    }
}
