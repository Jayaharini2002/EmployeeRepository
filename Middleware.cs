

using System.Text;


namespace ListEmployees1
{
    
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public Middleware(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;
            _logger = logFactory.CreateLogger("MyMiddleware");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("MyMiddleware executing..");
            String loggerData = $"Powered by OJCommerce.com";

            httpContext.Response.Headers.Add("Message", loggerData);
           
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
    
}
