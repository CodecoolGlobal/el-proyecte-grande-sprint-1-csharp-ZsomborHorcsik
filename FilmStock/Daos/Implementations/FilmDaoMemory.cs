using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class FilmDaoMemory : IFilmDao
    {
        private readonly List<MovieModel> _data;
        private static FilmDaoMemory? _instance = null;

        public FilmDaoMemory()
        {
            _data = new List<MovieModel>();
        }

        public static FilmDaoMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FilmDaoMemory();
            }
            return _instance;
        }

        public void Add(MovieModel film)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void GetMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAllMovies()
        {
            throw new NotImplementedException();
        }
    }
}
