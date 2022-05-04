﻿using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface IFilmDao
    {
        void Add(MovieModel film);
        void Remove(string id);
        MovieModel GetMovie(string id);
        IEnumerable<MovieModel> GetAll();
        IEnumerable<MovieModel> GetTop100(int count);
    }
}
