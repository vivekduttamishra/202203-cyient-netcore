using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AssignmentDay3.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticatedMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if(path.HasValue && (path.Value.StartsWith("/profile") || path.Value.StartsWith("/protected")))
            {
                if(httpContext.Session.GetString("UserName")==null)
                {
                    httpContext.Response.Redirect("/account/index");
                }
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticatedMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticatedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticatedMiddleware>();
        }
    }
}
