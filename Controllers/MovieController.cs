﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IEnumerable<MovieModel> GetAll()
        {
            return _movieService.GetAll();
        }

        [HttpGet]
        public IEnumerable<MovieModel> TopMovies()
        {
            return _movieService.GetTop100();
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] string id, string title, string rating, string rank, string year)
        {
            MovieModel newMovie = new MovieModel();
            newMovie.Id = id;
            newMovie.Title = title;
            newMovie.Rating = rating;
            newMovie.Rank = rank;
            newMovie.Year = year;
            return Ok($"Movie added with name {newMovie.Title}");
        }
        [HttpPut]
        public IActionResult EditMovie([FromQuery] string id, [FromBody] string newTitle)
        {
            var requestedMovie = _movieService.GetMovie(id);
            requestedMovie.Title = newTitle;
            return Ok($"Movie with name {requestedMovie.Title} has been renamed to {newTitle}");
        }

        [HttpDelete]
        //tt0111161
        public IActionResult DeleteMovie(string Id)
        {
            _movieService.Remove(Id);
            return Ok("Movie removed!");
        }
    }
}
