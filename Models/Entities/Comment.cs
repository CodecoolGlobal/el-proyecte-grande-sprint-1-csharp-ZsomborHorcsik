using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id;

        public long ReviewId;

        public long UserId;

        public string? Content;

        public DateTime Date;

        public DateTime? EditDate;

    }
}
