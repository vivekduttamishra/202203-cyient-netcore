using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AssignmentDay3.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class postAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public postAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if (path.HasValue && (path.Value=="/postadmin"))
            {
                if (httpContext.Session.GetString("UserName") != null)
                {
                    if (httpContext.Session.GetString("Role") == "Editor")
                    {
                        httpContext.Response.Redirect("/postadmin/index");
                    }
                    else
                        httpContext.Response.Redirect("/postadmin/nofound");

                }
                else
                    httpContext.Response.Redirect("/postadmin/nofound");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class postAdminMiddlewareExtensions
    {
        public static IApplicationBuilder UsepostAdminMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<postAdminMiddleware>();
        }
    }
}
