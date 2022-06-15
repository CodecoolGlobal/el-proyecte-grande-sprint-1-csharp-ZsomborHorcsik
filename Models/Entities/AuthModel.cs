using Newtonsoft.Json;

namespace FilmStock.Models.Entities
{
    public class AuthModel
    {
        [JsonProperty("x-auth-token")]
        public string? Token { get; set; } 
    }
}
