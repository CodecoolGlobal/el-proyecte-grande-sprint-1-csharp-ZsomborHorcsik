using FilmStock.Models;
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
            services.AddDbContext<FilmContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddControllersWithViews();
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

        private async void GetData(IHost host)
        {
            var apiLib = new ApiLib("k_i94oi014");
            var response = await apiLib.Top250MoviesAsync();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<FilmRepository>();
                PopulateMemory(movieService, response, ContentType.movie);
            }
            response = await apiLib.Top250TVsAsync();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<FilmRepository>();
                PopulateMemory(movieService, response, ContentType.series);
            }
        }

        private void PopulateMemory(IFilmRepository FilmRepository, IMDbApiLib.Models.Top250Data data, ContentType type)
        {
            foreach(var movie in data.Items)
            {
                FilmRepository.Add(Convert(movie, type));
            }
        }

        private Movie Convert(IMDbApiLib.Models.Top250DataDetail movie, ContentType type)
        {
            Movie newMovie = new();
            newMovie.Type = type;
            newMovie.Rank = movie.Rank;
            newMovie.Title = movie.Title;
            newMovie.FullTitle = movie.FullTitle;
            newMovie.Year = movie.Year;
            newMovie.Image = movie.Image;
            newMovie.Crew = movie.Crew;
            newMovie.Rating = movie.IMDbRating;
            newMovie.IMDbRatingCount = movie.IMDbRatingCount;
            return newMovie;
        }
    }
}