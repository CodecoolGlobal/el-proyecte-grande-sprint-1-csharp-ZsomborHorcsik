using Newtonsoft.Json;

namespace FilmStock.Models.Entities
{
    public class LoginModel
    {
        [JsonProperty("UserName")]
        public string? UserName { get; set; }

        [JsonProperty("Password")]
        public string? Password { get; set; }
    }
}
