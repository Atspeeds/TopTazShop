using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ServiceHost.Utility.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class VisitorsIdRegistration
    {
        private readonly RequestDelegate _next;

        public VisitorsIdRegistration(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var cookieVisitorId = httpContext.Request.Cookies["VisitorId"];
            if (string.IsNullOrWhiteSpace(cookieVisitorId))
            {
                var guid = Guid.NewGuid();
                httpContext.Response.Cookies.Append("VisitorId", guid.ToString(),
                   new CookieOptions
                   {
                       Expires = DateTime.Now.AddDays(30),
                       HttpOnly = true,
                       Path = "/"
                   });

            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class VisitorsIdRegistrationExtensions
    {
        public static IApplicationBuilder UseVisitorsIdRegistration(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VisitorsIdRegistration>();
        }
    }
}
