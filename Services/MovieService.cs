using FilmStock.Daos;
using FilmStock.Models;
using Newtonsoft.Json;

namespace FilmStock.Services
{
    public class MovieService
    {
        private readonly IFilmDao _filmMemory;

        public MovieService(IFilmDao FilmDao)
        {
            _filmMemory = FilmDao;
            GenerateMovieDb();
        }

        public void Add(MovieModel movie)
        {
            _filmMemory.Add(movie);
        }

        public void Remove(string id)
        {
            _filmMemory.Remove(id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _filmMemory.GetAll();
        }

        public IEnumerable<MovieModel> GetTop100()
        {
            return _filmMemory.GetTop100();
        }

        private async void GenerateMovieDb()
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
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<MovieListModel>(body);
            PopulateMemory(data);
        }

        private void PopulateMemory(MovieListModel movieData)
        {
            foreach(var movie in movieData.movies)
            {
                _filmMemory.Add(movie);
            }
        }
    }
}
