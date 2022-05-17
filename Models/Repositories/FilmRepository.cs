using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmStock.Models.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private FilmContext _db;
        
        public FilmRepository(FilmContext Context)
        {
            _db = Context;
        }
        public async Task Add(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
        }
        public async Task Remove(long id)
        {
            _db.Movies.Remove(_db.Movies.Where(movie => movie.Id == id).First());
            await _db.SaveChangesAsync();
        }

        public async Task Update(Movie movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }
        public Task<Movie?> GetMovie(long id)
        {
            return Task.Run(() => _db.Movies.FirstOrDefaultAsync(movie => movie.Id == id));
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _db.Movies
                            .Where(movie => movie.Type == ContentType.movie)
                            .OrderByDescending(movie => movie.Rating).ToListAsync();
        }
        public Task<List<Movie>> GetAllSeries()
        {
            return Task.Run(() => _db.Movies
                                    .Where(movie => movie.Type == ContentType.series)
                                    .ToListAsync());
        }

        public Task<List<Movie>> GetTopMovies(int count)
        {
            return Task.Run(() => _db.Movies
                                    .OrderByDescending(movie => movie.Rating)
                                    .Take(count)
                                    .ToListAsync());
        }
    }
}
