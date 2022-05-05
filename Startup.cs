using FilmStock.Daos;
using FilmStock.Daos.Implementations;
using FilmStock.Models;
using FilmStock.Services;
using IMDbApiLib;

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

            GetData(app);
            app.Run();
        }

        private async void GetData(IHost host)
        {
            var apiLib = new ApiLib("k_i94oi014");
            var response = await apiLib.Top250MoviesAsync();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<MovieService>();
                PopulateMemory(movieService, response, ContentType.movie);
            }
            response = await apiLib.Top250TVsAsync();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<MovieService>();
                PopulateMemory(movieService, response, ContentType.series);
            }
        }

        private void PopulateMemory(MovieService movieService, IMDbApiLib.Models.Top250Data data, ContentType type)
        {
            foreach(var movie in data.Items)
            {
                movieService.Add(Convert(movie, type));
            }
        }

        private MovieModel Convert(IMDbApiLib.Models.Top250DataDetail movie, ContentType type)
        {
            MovieModel newMovie = new();
            newMovie.Id = Guid.NewGuid();
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