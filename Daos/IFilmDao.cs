using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface IFilmDao
    {
        void Add(MovieModel film);
        void Remove(int id);
        void GetMovie(int id);
        void GetAllMovies();
    }
}
