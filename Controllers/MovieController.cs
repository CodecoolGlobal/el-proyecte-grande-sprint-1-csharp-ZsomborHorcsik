﻿using Microsoft.AspNetCore.Mvc;
using FilmStock.Services;
using FilmStock.Models;
using FilmStock.Daos.Implementations;

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
            return Ok("Not implemented yet");
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public IActionResult DeleteMovie([FromQuery] string id)
        {
            _movieService.Remove(id);
            return Ok("Movie removed!");
        }
    }
}