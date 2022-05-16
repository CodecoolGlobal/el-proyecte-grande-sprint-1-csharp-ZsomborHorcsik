using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReviewId;

        public long UserId;

        public double? StarRating;

        public string Content;

        public long MovieId;

        public DateTime Date;

        public DateTime EditDate;

        public int VoteCount;
    }
}