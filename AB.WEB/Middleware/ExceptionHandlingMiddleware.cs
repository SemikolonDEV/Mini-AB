using AB.Domain.Exceptions;
using System.Text.Json;

namespace AB_API.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status400BadRequest
            };

            var response = new
            {
                error = ex.Message
            };

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
