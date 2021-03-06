using FilmStock.Models.Entities;

namespace FilmStock.Models.Interfaces
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task Update(User user);
        public Task Remove(long id);
        public Task<User?> GetUserById(long id);
        public Task<User?> GetUserByUsername(string name);
        Task<List<Movie>> GetCollection(string name);
        public Task AddToCollection(string username, long movieId);
    }
}
