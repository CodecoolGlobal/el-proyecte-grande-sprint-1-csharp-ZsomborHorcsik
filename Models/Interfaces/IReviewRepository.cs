using FilmStock.Models.Entities;

namespace FilmStock.Models.Interfaces
{
    public interface IReviewRepository
    {
        public Task Add(Review review, string user, long movieId);
        public Task Update(Review review);
        public Task Remove(long id);
        public Task<Review?> GetReview(long id);
        public Task<List<Review>> GetReviewsByUser(string user);
        public Task<List<Review>> GetReviewsByMovie(long id);
    }
}
