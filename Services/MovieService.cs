using FilmStock.Daos;
using FilmStock.Models;

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

        public IEnumerable<MovieModel> GetTop(int count)
        {
            return _filmDao.GetTop(count);
        }
        public MovieModel GetMovie(string id)
        {
            return _filmDao.GetMovie(id);
        }

        public IEnumerable<MovieModel> GetMoviesWith(string person)
        {
            return _filmDao.GetMoviesWith(person);
        }
    }
}
