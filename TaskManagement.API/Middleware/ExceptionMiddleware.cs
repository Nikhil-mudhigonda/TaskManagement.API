using System.Text.Json;

namespace TaskManagement.API.Middleware
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
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            var response = new
            {
                Message = "An unexpected error occurred.",
                Details = ex.Message
            };
            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
