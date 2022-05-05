using FilmStock.Models;

namespace FilmStock.Daos
{
    public interface IFilmDao
    {
        void Add(MovieModel film);
        void Remove(Guid id);
        MovieModel GetMovie(Guid id);
        IEnumerable<MovieModel> GetAll();
        IEnumerable<MovieModel> GetTop(int count);
        IEnumerable<MovieModel> GetMoviesWith(string person);
    }
}
