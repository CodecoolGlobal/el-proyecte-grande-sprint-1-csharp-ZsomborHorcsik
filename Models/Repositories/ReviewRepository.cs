using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmStock.Models.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private FilmContext _db;

        public ReviewRepository(FilmContext Context)
        {
            _db = Context;
        }

        public async Task Add(Review review, string user, long movieId)
        {
            review.Date = DateTime.Now;
            review.userName = user;
            review.MovieId = movieId;
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();
        }

        public async Task<Review?> GetReview(long id)
        {
            return await _db.Reviews.FirstOrDefaultAsync(review => review.ReviewId == id);
        }

        public async Task<List<Review>> GetReviewsByMovie(long id)
        {
            return await _db.Reviews.Where(review => review.MovieId == id).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByUser(string user)
        {
            return await _db.Reviews.Where(review => review.userName == user).ToListAsync();
        }

        public async Task Remove(long id)
        {
            _db.Reviews.Remove(_db.Reviews.Where(review => review.ReviewId == id).First());
            await _db.SaveChangesAsync();
        }

        public async Task Update(Review review)
        {
            _db.Reviews.Update(review);
            await _db.SaveChangesAsync();
        }
    }
}
