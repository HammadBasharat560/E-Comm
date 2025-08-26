namespace E_Comm.Server.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); // forward the request
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                httpContext.Response.ContentType = "application/json";

                var statusCode = ex switch
                {
                    ArgumentException => StatusCodes.Status400BadRequest,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                httpContext.Response.StatusCode = statusCode;

                var errorResponse = new
                {
                    statusCode,
                    message = _env.IsDevelopment() ? ex.Message : "An error occurred. Please try again later."
                };

                await httpContext.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }

}
