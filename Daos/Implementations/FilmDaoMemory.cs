using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class FilmDaoMemory : IFilmDao
    {
        private readonly List<MovieModel> _data = new() { };

        public FilmDaoMemory()
        {
        }

        public void Add(MovieModel movie)
        {
            _data.Add(movie);
        }

        public void Remove(string id)
        {
            _data.Remove(this.GetMovie(id));
        }

        public MovieModel GetMovie(string id)
        {
            return _data.Single(movie => movie.Id == id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _data;
        }

        public IEnumerable<MovieModel> GetTop(int count)
        {
            return _data.OrderBy(movie => movie.Rank).Take(count);
        }

        public IEnumerable<MovieModel> GetTop100(int count)
        {
            throw new NotImplementedException();
        }
    }
}
 