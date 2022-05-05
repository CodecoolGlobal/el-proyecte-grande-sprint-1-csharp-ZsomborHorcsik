using Microsoft.AspNetCore.Mvc;
using FilmStock.Services;
using FilmStock.Models;

namespace FilmStock.Controllers
{
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/GetAll")]
        public IEnumerable<MovieModel> GetAll()
        {
            return _movieService.GetAll();
        }

        [HttpGet("/TopMovies/{count}")]
        public IEnumerable<MovieModel> TopMovies(int count)
        {
            return _movieService.GetTop(count);
        }

        [HttpPost("/AddMovie")]
        public IActionResult AddMovie([FromBody] string title, string rating, string rank, string year)
        {
            MovieModel newMovie = new();
            newMovie.Id = Guid.NewGuid();
            newMovie.Title = title;
            newMovie.Rating = rating;
            newMovie.Rank = rank;
            newMovie.Year = year;
            return Ok($"Movie added with name {newMovie.Title}");
        }

        [HttpPut("/EditMovie/{Id}")]
        public IActionResult EditMovie(Guid Id, [FromBody] MovieModel movieData)
        {
            var requestedMovie = _movieService.GetMovie(Id);
            requestedMovie.Title = movieData.Title;
            return Ok($"Movie has been renamed to {movieData.Title}");
        }

        [HttpDelete("/DeleteMovie/{Id}")]
        public IActionResult DeleteMovie(Guid Id)
        {
            _movieService.Remove(Id);
            return Ok("Movie removed!");
        }

        [HttpGet("/SearchPerson/{person}")]
        public IEnumerable<MovieModel> TopMovies(string person)
        {
            return _movieService.GetMoviesWith(person);
        }

        [HttpGet("/AddMovieToCollection/{Id}")]
        public void AddMovieToCollection(Guid Id)
        {
            _movieService.AddToCollection(Id);
        }

        [HttpGet("/RemoveMovieFromCollection/{Id}")]
        public void RemoveMovieFromCollection(Guid Id)
        {
            _movieService.RemoveFromCollection(Id);
        }

        [HttpGet("/Collection")]
        public IEnumerable<MovieModel> GetCollection()
        {
            return _movieService.GetCollection();
        }
    }
}
