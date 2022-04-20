using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface IFilmDao
    {
        void Add(FilmModel film);
        void Remove(int id);
        void GetMovie(int id);
        void GetAllMovies();
    }
}
