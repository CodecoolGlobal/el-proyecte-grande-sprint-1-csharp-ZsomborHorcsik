namespace FilmStock.Models
{
    public class MovieModel
    {
        public MovieModel()
        {
        }

        public MovieModel(string? id, string? rank, string? title, string? fullTitle, string? year, string? image, string? crew, string? iMDbRating, string? iMDbRatingCount)
        {
            Id = id;
            Rank = rank;
            Title = title;
            FullTitle = fullTitle;
            Year = year;
            Image = image;
            Crew = crew;
            IMDbRating = iMDbRating;
            IMDbRatingCount = iMDbRatingCount;
        }

        public string? Id { get; set; }
        public string? Rank { get; set; }
        public string? Title { set; get; }
        public string? FullTitle { set; get; }
        public string? Year { set; get; }
        public string? Image { get; set; }
        public string? Crew { get; set; }
        public string? IMDbRating { get; set; }
        public string? IMDbRatingCount { get; set; }
    }
}
