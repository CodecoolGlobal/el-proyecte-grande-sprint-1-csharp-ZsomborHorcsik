using Microsoft.AspNetCore.Mvc;
using FilmStock.Services;
using FilmStock.Models;
using FilmStock.Daos.Implementations;
using FilmStock.Daos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmStock.Controllers
{
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }


        // GET api/all-movies
        [HttpGet("/all-movies")]
        public IEnumerable<MovieModel> GetALl()
        {
            return _movieService.GetAll();
        }

        // GET api/top100-movies
        [HttpGet("/get-top-movies")]
        public IEnumerable<MovieModel> GetTop100()
        {
            return _movieService.GetTop100();
        }

        // POST api/add-movie
        [HttpPost("/add-movie")]
        public IActionResult AddMovie(string id, string rank, string title, string fulltitle, string year, string image, string crew, string imdbrating, string imdbratingcount)
        {
            MovieModel movie = new(id, rank, title, fulltitle, year, image, crew, imdbrating, imdbratingcount) { };
            _movieService.Add(movie);
            return Ok($"Movie added, name : {movie.Title}");
        }

        // PUT title
        [HttpPut("update/{title}")]
        public IActionResult Put(string title, [FromBody] string value)
        {
            return Ok("Not implemented yet");
        }

        // DELETE delete/id
        [HttpDelete("{delete/{id}")]
        public IActionResult Delete(string id)
        {
            _movieService.Remove(Convert.ToInt32(id));
            return Ok("Movie removed!");
        }
    }
}
