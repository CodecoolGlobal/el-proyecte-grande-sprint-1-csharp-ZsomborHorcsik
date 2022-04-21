using FilmStock.Daos;
using FilmStock.Daos.Implementations;
using FilmStock.Models;

namespace FilmStock.Services
{
    public class MovieService
    {
        private readonly IFilmDao _filmMemory;

        public MovieService(IFilmDao FilmDao)
        {
            _filmMemory = FilmDao;
        }

        public void Add(MovieModel movie)
        {
            _filmMemory.Add(movie);
        }

        public void Remove(int id)
        {
            _filmMemory.Remove(id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _filmMemory.GetAll();
        }

        public IEnumerable<MovieModel> GetTop100()
        {
            return _filmMemory.GetTop100();
        }


    }
}
