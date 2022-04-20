using FilmStock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            await ReturnTop250MoviesAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task ReturnTop250MoviesAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-scraper.p.rapidapi.com/top250"),
                Headers =
            {
                { "X-RapidAPI-Host", "imdb-scraper.p.rapidapi.com" },
                { "X-RapidAPI-Key", "bd9c8c9af3msh65dc378a78eccb8p13c00fjsna740695e6950" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }

    }
}