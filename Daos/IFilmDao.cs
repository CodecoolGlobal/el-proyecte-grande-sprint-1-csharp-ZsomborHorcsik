using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface IFilmDao
    {
        void Add(MovieModel film);
        void Remove(int id);
        MovieModel GetMovie(int id);
        IEnumerable<MovieModel> GetAll();
    }
}
