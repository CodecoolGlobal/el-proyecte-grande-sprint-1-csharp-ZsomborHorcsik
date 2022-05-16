using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models.Interfaces;
using IMDbApiLib;


namespace FilmStock.Utilities
{ 
    public class Helper
    { 
        public async void GetData(IFilmRepository filmRepository)
        {
            var apiLib = new ApiLib("k_i94oi014");
            var response = await apiLib.Top250MoviesAsync();
            PopulateMemory(filmRepository, response, ContentType.movie);
            response = await apiLib.Top250TVsAsync();
            PopulateMemory(filmRepository, response, ContentType.series);
        }

        private void PopulateMemory(IFilmRepository FilmRepository, IMDbApiLib.Models.Top250Data data, ContentType type)
        {
            foreach (var movie in data.Items)
            {
                FilmRepository.Add(Convert(movie, type));
            }
        }

        private Movie Convert(IMDbApiLib.Models.Top250DataDetail movie, ContentType type)
        {
            Movie newMovie = new();
            newMovie.Type = type;
            newMovie.Rank = movie.Rank;
            newMovie.Title = movie.Title;
            newMovie.FullTitle = movie.FullTitle;
            newMovie.Year = movie.Year;
            newMovie.Image = movie.Image;
            newMovie.Crew = movie.Crew;
            newMovie.Rating = movie.IMDbRating;
            newMovie.IMDbRatingCount = movie.IMDbRatingCount;
            return newMovie;
        }
    }
}