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
        void AddMovieToCollection(Guid id);
        void RemoveFromCollection(Guid id);
        IEnumerable<MovieModel> GetCollection();
        IEnumerable<MovieModel> GetAllMovies();
        IEnumerable<MovieModel> GetAllSeries();

    }
}
