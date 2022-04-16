using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMVC.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloMVC
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IMultiplicationTableGenerator, MultiplicationTableGenerator>();
            services.AddTransient<SimpleMath>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            


            app.Use(next => async context =>
           {
               if (context.Request.Path == "/error")
                   throw new Exception("Something really bad will happen if you go looking for troble");
               else
                   await next(context);
           });

            app.Use(next => async context =>
            {
                if (context.Request.Path == "/time")
                    await context.Response.WriteAsync(DateTime.Now.ToLongTimeString());
                else
                    await next(context);
            });

            app.UseFileServer(true);

            app.UseRouting();
            app.UseEndpoints(builder =>
            {

                builder.MapControllerRoute("MathRoute",
                   "m/{action}/{number1}/{number2}",
                   new { controller = "math", action = "Index", number1 = 0, number2 = 0 }
                   );

                builder.MapControllerRoute("MvcRoute",
                    "{controller}/{action}/{id}",
                    new { controller = "Home", action = "Index", id = "" }
                    );

               
            });

        }
    }
}
