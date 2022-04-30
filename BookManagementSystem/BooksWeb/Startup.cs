using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.Repositories.FlatFileRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using BooksWeb.Utils;
using ConceptArchitect.BookManagement.EFRepository;
using Microsoft.EntityFrameworkCore;

namespace BooksWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddSingleton<IAuthorService, InMemoryAuthorService>();

            // ConfigureFlatFileRepository(services);


            services.AddDbContext<BMSContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("BMSContext"));                
            });

            services.AddTransient<IAuthorRepository, EFAuthorRepository>();

            services.AddTransient<IAuthorService, PersistentAuthorService>();
            services.AddTransient<BookManagerRecordCreator>();
        }

        private void ConfigureFlatFileRepository(IServiceCollection services)
        {
            services.AddSingleton<BookStore>(provider =>
            {
                var baseDir = Environment.ContentRootPath;
                string path = Path.Join(baseDir, "Data", Configuration["bookStore"]);
                return BookStore.Load(path);
            });

            services.AddTransient<IAuthorRepository, FlatFileAuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();


            app.Use404ForInvalidEntityException();
            

            app.UseRouting();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Author}/{action=Index}/{id?}");

                
            });
        }
    }
}
