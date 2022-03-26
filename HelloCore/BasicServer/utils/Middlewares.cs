using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicServer.utils
{
    public static class Middlewares
    {
        public static IApplicationBuilder UseOnUrl(this IApplicationBuilder app,string url, RequestDelegate middleware)
        {

            url = url.ToLower();
            Console.WriteLine("middleware configured for " + url);
            app.Use(next => async context =>
            {
                if (context.Request.Path==url)
                    await middleware(context);
                else
                    await next(context);
            });

            

            return app;
        }


        public static IApplicationBuilder UseBefore(this IApplicationBuilder app, RequestDelegate middleware)
        {
           return app.Use(next => async context =>
           {

               await middleware(context); //my task will run

               await next(context); //rest of the middleware will get a chance to run

           });

            return app;
        }

        public static IApplicationBuilder UseAfter(this IApplicationBuilder app, RequestDelegate middleware)
        {
            return app.Use(next => async context =>
            {
                //first let other middleware fun
                await next(context); //rest of the middleware will get a chance to run

                //on return journey I may do something.
                await middleware(context); //my task will run

            });

            return app;
        }
    }
}
