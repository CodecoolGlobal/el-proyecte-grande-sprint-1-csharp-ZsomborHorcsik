using FilmStock.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserLevel Level { get; set; }
    }

}

