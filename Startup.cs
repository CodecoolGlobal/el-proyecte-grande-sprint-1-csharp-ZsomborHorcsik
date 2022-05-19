using FilmStock.Data;
using FilmStock.Models;
using FilmStock.Models.Interfaces;
using FilmStock.Models.Repositories;
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = false;
            });
            services.AddHttpContextAccessor();
            services.AddTransient<DbInitializer>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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
            app.UseSession();

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