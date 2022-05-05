using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public interface IReviewDao
    {
        void Add(ReviewModel movie);
        void Delete(Guid reviewId);
        IEnumerable<ReviewModel> GetReviewsByUser(Guid id);
        IEnumerable<ReviewModel> GetReviewsByMovie(string id);
        ReviewModel GetReviewById(Guid id);
        void VoteUp(Guid id);
        void VoteDown(Guid id);
    }
}
