using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicServer.services;
using BasicServer.utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BasicServer
{
    public class Startup
    {

        public Startup()
        {
            Console.WriteLine("Startup object created");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            
            //services is where you configure you back-end classes
            // that will do the "real work"
            // You business logic and basically everything that is not direclty dealing with HTTP.

            services.AddSingleton<SimpleGreetService>();
            services.AddSingleton<IGreetService, ConfigurableGreetService3>();
            services.AddSingleton<TimeName>();
            services.AddSingleton<IFormatterService, UpperCaseFormatter>();

            services.AddSingleton<IAuthenticationService, DummyAuthenticationService>();

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {

            //Logger Middleware

            logger.LogInformation($"Current Environment: {env.EnvironmentName}");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/error.html");
            }


            app.UseAuthneticationEndPoints(); //this will give you /login and /logout




            app
                .UseBefore(async context =>
                {
                    Console.WriteLine("Before {0} {1} {2}", context.Request.Method, context.Request.Path,context.Response.StatusCode);
                    await Task.Delay(1);
                })
                .UseAfter(async context =>
                {
                    Console.WriteLine("After {0} {1} {2}", context.Request.Method, context.Request.Path,context.Response.StatusCode);
                    await Task.Delay(1);
                })
                .UseOnUrl( "/time", async context =>
                {
                    Console.WriteLine("/time middleware called");
                    await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
                })
                .UseOnUrl( "/welcome", async context =>
                {
                    await context.Response.WriteAsync(string.Format("Welcome {0}, to your web server", context.Request.Query["name"]));
                });


            app.UseOnUrl("/faulty", async context =>
            {
                await Task.Delay(10);
                throw new Exception("Your secret key has reached usage limit: 393939393");
            });


            //everything below this point should be authorized
            //app.UseAuthenticate();


            

            app.UseAuthenticate("/profile", async context =>
            {
                var user = context.Request.Headers["user"];
                await context.Response.WriteAsync($"Current User is :{user}");
            });


            app.UseAuthenticate("/protected", async context =>
            {
                var user = context.Request.Headers["user"];
                await context.Response.WriteAsync($"Protected resource for  :{user}");
            });

            //app.UseOnUrl("/profile", async context =>
            // {
            //     var user = context.Request.Headers["user"];
            //     await context.Response.WriteAsync($"Current User is :{user}");
            // });



            app.UseOnUrl("/greet3", async context =>
            {
                //get parameter from the request
                var name = context.Request.Query["name"];

                //get the service to get the required data
                //var service = context
                //                .RequestServices
                //                .GetService<IGreetService>();


                var service = app.ApplicationServices.GetService<IGreetService>();
                

                //get the data
                var data = service.Greet(name);

                await context.Response.WriteAsync(data);


            });





            app.UseOnUrl("/greet2", async context =>
            {
                //get parameter from the request
                var name = context.Request.Query["name"];

                //get the service to get the required data
                var service = context
                                .RequestServices
                                .GetService<SimpleGreetService>();
                //get the data
                var data = service.Greet(name);

                await context.Response.WriteAsync(data);


            });

            app.UseOnUrl("/greet1", async context =>
            {
                //get parameter from the request
                var name = context.Request.Query["name"];

                //get the service to get the required data
                var service = new SimpleGreetService();
                //get the data
                var data = service.Greet(name);
                
                await context.Response.WriteAsync(data);
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

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            Console.WriteLine("Reached Beyond UseFileServer");


            //for other url's control will reach here.
            //app.Run(async context =>
            //{
            //    Console.WriteLine("Reached in Final Run");
            //    await context.Response.WriteAsync("Hello World on " + context.Request.Path);
            //});


            
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
