using FilmStock.Models.Entities;
using FilmStock.Models.Interfaces;

namespace FilmStock.Models.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private FilmContext _db;
        
        public FilmRepository(FilmContext Context)
        {
            _db = Context;
        }
        public Task Add(Movie movie)
        {
            throw new NotImplementedException();
        }
        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Movie movie)
        {
            throw new NotImplementedException();
        }
        public Task<Movie> GetMovie(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllSeries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopMovies(int count)
        {
            throw new NotImplementedException();
        }
    }
}
