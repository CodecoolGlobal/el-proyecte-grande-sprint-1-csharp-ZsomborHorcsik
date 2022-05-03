using FilmStock.Models;

namespace FilmStock.Daos.Implementations
{
    public class ReviewDaoMemory : IReviewDao
    {
        private readonly List<ReviewModel> _data = new() { };

        public ReviewDaoMemory()
        {
        }

        public void Add(ReviewModel review)
        {
            _data.Add(review);
        }

        public void Delete(Guid id)
        {
            _data.Remove(_data.Single(review => review.ReviewId == id));
        }

        public IEnumerable<ReviewModel> GetByUser(Guid id)
        {
            var reviews = _data.Where(review => review.UserId == id);
            return reviews;
        }
    }   
}
