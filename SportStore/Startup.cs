﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Models;
using SportsStore.Data;
using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Models;

namespace SportStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            



            services.AddMvc();
            services.AddSingleton(Configuration);
            //services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<IProductRepository, EFProductRepository>(); // so that Bookservice is injected into controllers and other components that request IBook


            // configure ef and dbcontext.
            // ef can now work with other databases, including non-relational
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SportStoreProducts")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();

            /*
             app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            */

            app.UseMvc(routes => {

                routes.MapRoute(name: "pagination",template: "Products/Page{page}",defaults: new { Controller = "Product", action = "List" });

                routes.MapRoute(
                name: "default",
               template: "{controller=Product}/{action=List}/{id?}");
            });

            //SeedData.EnsurePopulated(app);
        }
    }
}
