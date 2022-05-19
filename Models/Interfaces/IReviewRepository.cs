using FilmStock.Models.Entities;

namespace FilmStock.Models.Interfaces
{
    public interface IReviewRepository
    {
        public Task Add(Review review);
        public Task Update(Review review);
        public Task Remove(long id);
        public Task<Review?> GetReview(long id);
        public Task<List<Review>> GetReviewsByUser(long id);
        public Task<List<Review>> GetReviewsByMovie(long id);

    }
}
