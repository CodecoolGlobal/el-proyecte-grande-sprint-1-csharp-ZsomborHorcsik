﻿using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class FilmDaoMemory : IFilmDao
    {
        private readonly List<MovieModel> _data = new() { };

        public FilmDaoMemory()
        {
        }

        public void Add(MovieModel movie)
        {
            _data.Add(movie);
        }

        public void Remove(string id)
        {
            _data.Remove(this.GetMovie(id));
        }

        public MovieModel GetMovie(string id)
        {
            return _data.Where(movie => movie.Id == id).First();
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _data;
        }

        public IEnumerable<MovieModel> GetTop100()
        {
            return _data.OrderBy(movie => movie.Rank).Take(100);
        }
    }
}
 