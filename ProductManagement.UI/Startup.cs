﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Repository.EF;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using ProductManagement.Services.Interfaces;
using ProductManagement.Services;
using AutoMapper;

namespace ProductManagement.UI
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
            services.AddDbContext<ProductsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAutoMapper();

            services.AddSingleton<AppSettings>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IProductsRepository>(serviceProvider => 
                new RepositoryFactory(serviceProvider.GetRequiredService<AppSettings>(), 
                    serviceProvider.GetRequiredService<ProductsContext>(), 
                    serviceProvider.GetRequiredService<IMapper>())
                    .Build());
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}/{id?}");
            });
        }
    }
}
