using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicServer
{
    public class StartupV1
    {

        public StartupV1()
        {
            Console.WriteLine("Startup object created");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("Services configured");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine("Configure function called");
            //Logger Middleware


            app.Use(TimeProvider); 



            app.Use(next => async context =>
            {
                //log the request info
                Console.WriteLine("{0} {1}", context.Request.Method, context.Request.Path);

                //let next middleware do the actual job.
                await next(context);
            });



            app.Use(next => async context =>
            {
                if (context.Request.Path == "/time")
                    await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
                else
                    await next(context);

            });

            app.Use(next => async context =>
            {
                if (context.Request.Path == "/welcome")
                    await context.Response.WriteAsync(string.Format("Welcome {0}, to your web server", context.Request.Query["name"]) );
                else
                    await next(context);

            });

            //app.UseDefaultFiles();  //change url to "/index.html" in case it is blank.
            //app.UseStaticFiles();    //searched for "/" . not fouund

            //above two can be repalced by
            app.UseFileServer();


            Console.WriteLine("Reached Beyond UseFileServer");


            //for other url's control will reach here.
            app.Run(async context =>
            {
                Console.WriteLine("Reached in Final Run");
                await context.Response.WriteAsync("Hello World on " + context.Request.Path);
            });


            
        }

        private RequestDelegate TimeProvider(RequestDelegate next)
        {

            Console.WriteLine("Inside 'Time Provider Middleware' Provider");

            //returns what this middleware should do
            return async context =>
            {
                Console.WriteLine("Inside Time Provider Middleware");

                await next(context); //I don't care about this URL. let the next middleware handle this url. 
                

                if (context.Request.Path.Value.Contains("/time"))
                    await context.Response.WriteAsync("\n"+DateTime.Now.ToLongTimeString()); //handle this URL

                
            };           

        }

        async Task SayHi(HttpContext context)
        {
            Console.WriteLine("Say Hi Called");
            await context.Response.WriteAsync("Hi World");
            
        }


        Task SayHello(HttpContext context)
        {
            
            //Task represents some work that may complete later.
            return context.Response.WriteAsync("Hello World");
        }
    }
}
