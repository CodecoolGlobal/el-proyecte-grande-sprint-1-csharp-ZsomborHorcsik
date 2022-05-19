using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReviewId;

        public string userName;

        public long? MovieId;
        [JsonProperty("starRating")]
        public double? StarRating;
        [JsonProperty("content")]
        public string Content;

        public DateTime Date;

        public DateTime? EditDate;

        public int? VoteCount;
    }
}