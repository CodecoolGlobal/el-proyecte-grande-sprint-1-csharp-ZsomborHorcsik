using FilmStock.Models;
using FilmStock.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace FilmStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Util _utilities;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _utilities = new Util();
        }

        [Route("/Home/Index")]
        public async Task<IActionResult> Index()
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
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var movies = JsonConvert.DeserializeObject<MovieListModel>(body);
            }
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
    }
}