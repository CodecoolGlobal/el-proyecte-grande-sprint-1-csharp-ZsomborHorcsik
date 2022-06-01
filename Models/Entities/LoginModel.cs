using Newtonsoft.Json;

namespace FilmStock.Models.Entities
{
    public class LoginModel
    {
        [JsonProperty("userName")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
