using FilmStock.Daos.Implementations;
using FilmStock.Models;

namespace FilmStock.Services
{
    public class MovieService
    {
        private readonly FilmDaoMemory filmDao;

        public MovieService(FilmDaoMemory filmDao?)
        {
            filmDao = filmDao;
        }

        public void Add(MovieModel movie)
        {
            filmDao.Add(movie);
        }

        public void Remove(int id)
        {
            filmDao.Remove(id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return filmDao.GetAll();
        }

        public IEnumerable<MovieModel> GetTop100()
        {
            return filmDao.GetTop100();
        }


    }
}
