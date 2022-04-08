using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AssignmentDay3.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class productAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public productAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            if (path.HasValue && (path.Value=="/productadmin"))
            {
                if (httpContext.Session.GetString("UserName") != null)
                {
                    if (httpContext.Session.GetString("Role") == "Admin")
                    {
                        httpContext.Response.Redirect("/productadmin/showview");
                    }
                    else
                        httpContext.Response.Redirect("/productadmin/nofound");

                }
                else
                    httpContext.Response.Redirect("/useradmin/nofound");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class productAdminMiddlewareExtensions
    {
        public static IApplicationBuilder UseproductAdminMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<productAdminMiddleware>();
        }
    }
}
