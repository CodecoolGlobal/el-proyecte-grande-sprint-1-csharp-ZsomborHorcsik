using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class FilmDaoMemory
    {
        private readonly List<FilmModel> _data;
        private static FilmDaoMemory? _instance = null;

        public FilmDaoMemory()
        {
            _data = new List<FilmModel>();
        }

        public static FilmDaoMemory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FilmDaoMemory();
            }
            return _instance;
        }
    }
}
