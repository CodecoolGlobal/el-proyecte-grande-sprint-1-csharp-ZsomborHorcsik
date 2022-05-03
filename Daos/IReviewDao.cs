using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public interface IReviewDao
    {
        void Add(ReviewModel movie);
        void Delete(Guid reviewId);
        IEnumerable<ReviewModel> GetReviewsByUser(Guid id);
    }
}
