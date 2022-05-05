using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class FilmDaoMemory : IFilmDao
    {
        private readonly List<MovieModel> _data = new() { };

        private readonly List<MovieModel> _collection = new() { };

        public FilmDaoMemory()
        {
        }

        public void Add(MovieModel movie)
        {
            _data.Add(movie);
        }

        public void Remove(Guid id)
        {
            _data.Remove(this.GetMovie(id));
        }

        public MovieModel GetMovie(Guid id)
        {
            return _data.Single(movie => movie.Id == id);
        }

        public IEnumerable<MovieModel> GetAll()
        {
            return _data;
        }

        public IEnumerable<MovieModel> GetTop(int count)
        {
            return _data.OrderByDescending(movie => movie.Rating).Take(count);
        }

        public IEnumerable<MovieModel> GetMoviesWith(string person)
        {
            return _data.Where(movie => movie.Crew.Contains(person));
        }

        public void AddMovieToCollection(Guid id)
        {
            MovieModel movie = GetMovie(id);
            _collection.Add(movie);
        }

        public void RemoveFromCollection(Guid id)
        {
            _collection.Remove(this.GetMovie(id));
        }

    }
}
 