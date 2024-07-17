using Newtonsoft.Json;
using PrimeEngineeringApi.Utilities.Exceptions;
using Serilog;

namespace PrimeEngineeringApi.Middleware
{
    public class ExceptionhandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionhandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status404NotFound);
            }
            catch (UnauthorizedException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status401Unauthorized);
            }
            catch (IdentityException ex)
            {
                var message = string.Join(' ', ex.Errors.Select(x => x.Description));
                await HandleExceptionAsync(httpContext, message, StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                await HandleExceptionAsync(httpContext, "Something went wrong", StatusCodes.Status500InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var result = JsonConvert.SerializeObject(new { error = message });
            Log.Error(result);
            return context.Response.WriteAsync(result);
        }
    }
}
