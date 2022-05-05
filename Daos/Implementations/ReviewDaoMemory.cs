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

        public IEnumerable<ReviewModel> GetReviewsByUser(Guid id)
        {
            var reviews = _data.Where(review => review.UserId == id);
            return reviews;
        }

        public IEnumerable<ReviewModel> GetReviewsByMovie(string id)
        {
            var reviews = _data.Where(review => review.MovieId == id);
            return reviews;
        }

        public ReviewModel GetReviewById(Guid id)
        {
            var review = _data.Where(review => review.ReviewId == id).First();
            return review;
        }

        public void VoteUp(Guid id)
        {
            ReviewModel review = GetReviewById(id);
            review.VoteCount++;
        }

        public void VoteDown(Guid id)
        {
            ReviewModel review = GetReviewById(id);
            review.VoteCount--;
        }
    }   
}
