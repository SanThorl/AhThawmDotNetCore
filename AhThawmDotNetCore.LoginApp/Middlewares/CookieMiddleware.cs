using AhThawmDotNetCore.LoginApp.EFDbContext;

namespace AhThawmDotNetCore.LoginApp.Middlewares
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        public async Task InvokeAsync(HttpContext httpContext, AppDbContext appDbContext)
        {
            await _next(httpContext);
        }

        public static class CookieMiddlewareExtentions
        {
            public static IApplicationBuilder UseMyCustomMiddleware( this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<CookieMiddleware>();
            }
        }
    }
}
