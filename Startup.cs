using FilmStock.Daos;
using FilmStock.Daos.Implementations;
using FilmStock.Models;
using FilmStock.Services;
using IMDbApiLib;
using Newtonsoft.Json;

namespace FilmStock
{
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;

        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
            ConfigureStartup();
        }

        private void ConfigureStartup()
        {
            _builder.Services.AddControllersWithViews();
            _builder.Services.AddSingleton<IFilmDao, FilmDaoMemory>();
            _builder.Services.AddSingleton<IReviewDao, ReviewDaoMemory>();
            _builder.Services.AddSingleton<ICommentDao, CommentDaoMemory>();
            _builder.Services.AddScoped<MovieService>();
            _builder.Services.AddScoped<ReviewService>();
            _builder.Services.AddScoped<CommentService>();
            _builder.Services.AddCors();

            var app = _builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors(op =>
            {
                op.WithOrigins("http://localhost:3000")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=GetAll}");

            GetMoviesData(app);
            app.Run();
        }

        private async void GetMoviesData(IHost host)
        {
            var apiLib = new ApiLib("k_i94oi014");
            var response = await apiLib.Top250MoviesAsync();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<MovieService>();
                PopulateMemory(movieService, response);
            } 
        }

        private void PopulateMemory(MovieService movieService, IMDbApiLib.Models.Top250Data data)
        {
            foreach(var movie in data.Items)
            {
                movieService.Add(Convert(movie));
            }
        }

        private MovieModel Convert(IMDbApiLib.Models.Top250DataDetail movie)
        {
            MovieModel newMovie = new();
            newMovie.Id = movie.Id;
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