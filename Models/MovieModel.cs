using Newtonsoft.Json;

namespace FilmStock.Models
{
    public class MovieModel
    {
        [JsonProperty("movieId")]
        public string Id { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Rating")]
        public string Rating { get; set; }
    }
}