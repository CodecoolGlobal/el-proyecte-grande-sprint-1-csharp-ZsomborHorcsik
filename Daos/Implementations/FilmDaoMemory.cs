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

        public void Add(MovieModel movie)
        {
            _data.Add(movie);
        }

        public void Remove(int id)
        {
            _data.Remove(this.GetMovie(id));
        }

        public MovieModel GetMovie(int id)
        {
                return _data.Find(movie => Convert.ToInt32(movie.Id) == id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _data;
        }
    }
}
