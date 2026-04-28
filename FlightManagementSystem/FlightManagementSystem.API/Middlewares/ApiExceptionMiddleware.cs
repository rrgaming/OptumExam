using FlightManagementSystem.Application.Models;
using System.Text.Json;

namespace FlightManagementSystem.API.Middlewares
{

    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(new { error = ex.Error, message = ex.Message });
                await context.Response.WriteAsync(result);
            }
        }
    }
}
