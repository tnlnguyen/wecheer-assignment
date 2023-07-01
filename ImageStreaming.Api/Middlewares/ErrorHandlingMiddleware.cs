using System;
using ImageStreaming.Shared.Persistence.Common.Exceptions;
using ImageStreaming.Shared.Persistence.Common.Extensions;

namespace ImageStreaming.Api.Middlewares
{
	public class ErrorHandlingMiddleware
	{
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                _logger.LogError(error, error.Message);

                var result = JsonExtensions.SerializeObject(new { message = error?.Message });
                int statusCode;
                if (error is UnauthorizedAccessException)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }
                else if (error is BaseException baseException)
                {
                    statusCode = (int)baseException.Code;
                }
                else
                {
                    statusCode = StatusCodes.Status500InternalServerError;
                }

                response.StatusCode = statusCode;
                await response.WriteAsync(result);
            }
        }
    }
}

