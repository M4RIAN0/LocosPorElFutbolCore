using Microsoft.AspNetCore.Http;

namespace Lxf.Support
{
    public sealed class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }

    }
}