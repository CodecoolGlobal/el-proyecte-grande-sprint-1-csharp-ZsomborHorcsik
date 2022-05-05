namespace FilmStock.Models
{
    public class ReviewModel
    {
        public Guid ReviewId;

        public Guid UserId;

        public double? StarRating;

        public string? Review;

        public string MovieId;

        public DateTime Date;

        public DateTime EditDate;

        public int VoteCount;
    }
}