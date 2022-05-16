﻿using FilmStock.Models;
using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Repositories;
using IMDbApiLib;
using Microsoft.EntityFrameworkCore;

namespace FilmStock
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<FilmContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(op =>
            {
                op.WithOrigins("http://localhost:3000")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}