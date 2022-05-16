﻿using Microsoft.AspNetCore.Mvc;
using FilmStock.Models.Interfaces;
using FilmStock.Utilities;
using FilmStock.Models.Entities;

namespace FilmStock.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly Helper _helper;
        public MovieController(IFilmRepository FilmRepository)
        {
            _filmRepository = FilmRepository;
            _helper = new Helper();
        }

        [HttpGet("testroute")]
        public IActionResult GetAllData()
        {
            _helper.GetData(_filmRepository);
            return Ok();
        }

        [HttpGet("Movies")]
        public async Task<List<Movie>> GetAllMovies()
        {
            return await _filmRepository.GetAllMovies();
        }

        [HttpGet("Series")] 
        public async Task<List<Movie>> GetAllSeries()
        {
            return await _filmRepository.GetAllSeries();
        }

        [HttpGet("top/{count:int}")]
        public async Task<List<Movie>> TopMovies(int count)
        {
            return await _filmRepository.GetTopMovies(count);
        }

        [HttpPost("new")]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await _filmRepository.Add(movie);
            return CreatedAtAction("Movie created", new { movie.Id }, movie);

        }

        [HttpPut("edit/{Id}")]
        public void EditMovie(long Id, [FromBody] Movie movie)
        {
            movie.Id = Id;
            _filmRepository.Update(movie);
        }

        [HttpDelete("delete/{Id}")]
        public async Task DeleteMovie(long Id)
        {
            await _filmRepository.Remove(Id);
        }
    }
}
