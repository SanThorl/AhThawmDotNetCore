using AhThawmDotNetCore.LoginApp.EFDbContext;
using Microsoft.EntityFrameworkCore;
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
            string requestUrl = httpContext.Request.Path.ToString().ToLower();
            if (requestUrl == "/login" || requestUrl == "/login/index")
                goto result;

            var cookies = httpContext.Request.Cookies;
            if (cookies["UserId"] is null || cookies["SessionId"] is null)
            {
                httpContext.Response.Redirect("/Login");
                goto result;
            }

            string userId = cookies["UserId"]!.ToString();
            string sessionId = cookies["SessionId"]!.ToString();

            var login = await appDbContext.Login.FirstOrDefaultAsync(x => x.SessionId == sessionId && x.UserId == userId);

            if (login is null)
            {
                httpContext.Response.Redirect("/Login");
                goto result;
            }

            if (DateTime.Now > login.SessionExpired)
            {
                httpContext.Response.Redirect("/Login");
                goto result;
            }

        result:
            await _next(httpContext);
        }
    }

    public static class CookieMiddlewareExtensions
    {
        public static IApplicationBuilder UseCookieMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CookieMiddleware>();
        }
    }
}
