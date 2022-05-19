using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmStock.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FilmContext _db;

        public UserRepository(FilmContext db)
        {
            _db = db;
        }

        public async Task Add(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(long id)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> GetUserByUsername(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.UserName == name);
        }

        public async Task Remove(long id)
        {
            _db.Users.Remove(_db.Users.Where(user => user.Id == id).First());
            await _db.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ValidateUser(LoginModel data)
        {
            var allUsers = _db.Users;
            if (allUsers.Where(user => user.UserName == data.UserName && user.Password == data.Password) != null)
            {
                return true;
            }
            return false;
        }
    }
}
