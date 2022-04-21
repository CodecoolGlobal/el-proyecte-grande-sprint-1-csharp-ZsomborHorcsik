using Microsoft.AspNetCore.Mvc;
using FilmStock.Services;
using FilmStock.Models;


namespace FilmStock.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("/all-movies")]
        public IEnumerable<MovieModel> GetALl()
        {
            return _movieService.GetAll();
        }

        [HttpGet("/get-top-movies")]
        public IEnumerable<MovieModel> GetTop100()
        {
            return _movieService.GetTop100();
        }

        [HttpPost("/add-movie")]
        public IActionResult AddMovie([FromBody] string id, string rank, string title, string fulltitle, string year, string image, string crew, string imdbrating, string imdbratingcount)
        {
            MovieModel movie = new(id, rank, title, fulltitle, year, image, crew, imdbrating, imdbratingcount) { };
            _movieService.Add(movie);
            return Ok($"Movie added, name : {movie.Title}");
        }

        [HttpPut("/update/{id}")]
        public IActionResult Put([FromQuery] string id, [FromBody] string newTitle)
        {
            return Ok("Not implemented yet");
        }

        [HttpDelete("/delete/{id}")]
        public IActionResult Delete([FromQuery] string id)
        {
            _movieService.Remove(id);
            return Ok("Movie removed!");
        }
    }
}
