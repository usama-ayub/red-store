using System.Net;
using System.Text.Json;

namespace eShopApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle 401 Unauthorized
                _logger.LogError(ex, "Unauthorized access.");
                await HandleExceptionAsync(context, ex, HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                // Handle all other exceptions
                _logger.LogError(ex, "Unhandled exception.");
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = _env.IsDevelopment()
                ? new ApiException((int)statusCode, ex.Message, ex.StackTrace?.ToString())
                : new ApiException((int)statusCode, statusCode == HttpStatusCode.Unauthorized ? "Unauthorized" : "Internal Server Error");

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(json);
        }

        public class ApiException
        {
            public ApiException(int status, string message = "", string details = "")
            {
                Status = status;
                Message = message;
                Details = details;
                Success = false;
                Error = true;
                Data = "";
            }

            public int Status { get; set; }
            public string Message { get; set; }
            public string Details { get; set; }
            public bool Success { get; set; }
            public bool Error { get; set; }
            public string Data { get; set; }
        }
    }
}
