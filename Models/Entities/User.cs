using FilmStock.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("userName")]
        public string? UserName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("password")]
        public string? Password { get; set; }
        public UserLevel Level { get; set; }
        public List<Movie>? Collection { get; set; }
    }

}

