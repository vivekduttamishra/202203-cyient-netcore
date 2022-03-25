using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDay2.Models
{
    public class PageRequestMiddleware
    {
        private readonly RequestDelegate _next;
        public PageRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.Path=="/" || context.Request.Path == "/time" || context.Request.Path == "/helloworld")
            {
                RequestCount.AddCount(context.Request.Path);
            }
            await _next(context);
        }
    }

    public static class PageRequestMiddlewareExtension
    {
        public static IApplicationBuilder UsePageRequestMiddleware(
            this IApplicationBuilder builder
            )
        {
            return builder.UseMiddleware<PageRequestMiddleware>();
        }
    }
}
