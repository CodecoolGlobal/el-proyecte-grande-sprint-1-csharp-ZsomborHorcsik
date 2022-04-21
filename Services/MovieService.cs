using FilmStock.Daos;
using FilmStock.Models;
using Newtonsoft.Json;

namespace FilmStock.Services
{
    public class MovieService
    {
        private readonly IFilmDao _filmDao;

        public MovieService(IFilmDao FilmDao)
        {
            _filmDao = FilmDao;
        }

        public void Add(MovieModel movie)
        {
            _filmDao.Add(movie);
        }

        public void Remove(string id)
        {
            _filmDao.Remove(id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _filmDao.GetAll();
        }

        public IEnumerable<MovieModel> GetTop100()
        {
            return _filmDao.GetTop100();
        }
        public MovieModel GetMovie(string id)
        {
            return _filmDao.GetMovie(id);
        }
    }
}
