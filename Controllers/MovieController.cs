using Microsoft.AspNetCore.Mvc;
using FilmStock.Services;
using FilmStock.Models;
using FilmStock.Daos.Implementations;
using FilmStock.Daos;
using 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FilmStock.Controllers
{
    public class MovieController : ControllerBase
    {
        public MovieService MovieService { get; private set; }

        public MovieController(FilmDaoMemory filmDao)
        {
            MovieService = new MovieService(
                FilmDaoMemory.GetInstance()
                );
        }


        // GET api/all-movies
        [HttpGet("/all-movies")]
        public IEnumerable<MovieModel> GetALl()
        {
            return MovieService.GetAll();
        }

        // GET api/top100-movies
        [HttpGet("/all-movies")]
        public IEnumerable<MovieModel> GetTop100()
        {
            return MovieService.GetTop100();
        }

        // POST api/add-movie
        [HttpPost("/add-movie")]
        public void AddMovie(string id, string rank, string title, string fulltitle, string year, string image, string crew, string imdbrating, string imdbratingcount)
        {
            MovieModel movie = new(id, rank, title, fulltitle, year, image, crew, imdbrating, imdbratingcount) { };
            MovieService.Add(movie);
        }

        // PUT title
        [HttpPut("update/{title}")]
        public void Put(string title, [FromBody] string value)
        {
        }

        // DELETE delete/id
        [HttpDelete("{delete/{id}")]
        public void Delete(string id)
        {
            MovieService.Remove(Convert.ToInt32(id));
        }
    }
}
