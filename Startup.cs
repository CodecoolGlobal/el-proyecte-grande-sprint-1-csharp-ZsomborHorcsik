using FilmStock.Daos;
using FilmStock.Daos.Implementations;
using FilmStock.Models;
using FilmStock.Services;
using Newtonsoft.Json;

namespace FilmStock
{
    public class Startup
    {
        private readonly WebApplicationBuilder _builder;
        private object _filmDao;

        public Startup(WebApplicationBuilder builder)
        {
            _builder = builder;
            ConfigureStartup();
        }

        private void ConfigureStartup()
        {
            _builder.Services.AddControllersWithViews();
            _builder.Services.AddSingleton<IFilmDao, FilmDaoMemory>();
            _builder.Services.AddScoped<MovieService>();

            var app = _builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            GetMoviesData(app);
            app.Run();
        }

        private async void GetMoviesData(IHost host)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-scraper.p.rapidapi.com/top250"),
                Headers =
                {
                    { "X-RapidAPI-Host", "imdb-scraper.p.rapidapi.com" },
                    { "X-RapidAPI-Key", "9116f684c8msh66dc01697128539p1485f7jsn12ff8745bba9" },
                },
            };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Console.WriteLine(body);
            var data = JsonConvert.DeserializeObject<MovieListModel>(body);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var movieService = services.GetRequiredService<MovieService>();
                PopulateMemory(movieService, data);
            }
            
        }

        private void PopulateMemory(MovieService movieService, MovieListModel data)
        {
            foreach(var movie in data.movies)
            {
                movieService.Add(movie);
            }
        }
    }
}