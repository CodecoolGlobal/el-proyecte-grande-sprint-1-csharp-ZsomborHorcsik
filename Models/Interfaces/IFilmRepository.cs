using FilmStock.Models.Entities;

namespace FilmStock.Models.Interfaces
{
    public interface IFilmRepository
    {
        public Task Add(Movie movie);
        public Task Update(Movie movie);
        public Task Remove(long id);
        public Task<Movie> GetMovie(long id);
        public Task<List<Movie>> GetAllMovies();
        public Task<IEnumerable<Movie>> GetAllSeries();
        public IEnumerable<Movie> GetTopMovies(int count);

    }
}
