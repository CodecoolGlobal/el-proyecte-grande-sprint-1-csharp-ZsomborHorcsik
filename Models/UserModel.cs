namespace FilmStock.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Comment> Comments { get; set; }

        public UserLevel Level { get; set; }
    }

    public enum UserLevel {
        user,
        premium,
        admin
    }

}

