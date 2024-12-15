using SSG.Application.Common.Exceptions;
using SSG.Application.Common.Models;
using SSG.Application.Models;

namespace SSG.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApplicationValidationException ex)
            {
                _logger.LogError(ex, "Validation error occurred.");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new ResponseModel<ReturnMessageModel>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.ErrorMessage,
                    ValidationErrors = ex.Errors,
                    Value = new ReturnMessageModel()
                    {
                        ReturnMessage = ex.ErrorMessage,
                        ValidationErrors = ex.Errors
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { Message = "An unexpected error occurred." });
            }
        }
    }
}
