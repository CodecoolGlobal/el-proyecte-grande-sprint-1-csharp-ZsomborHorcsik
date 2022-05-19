using FilmStock.Models.Entities;
using FilmStock.Models.Enums;
using FilmStock.Models;
using IMDbApiLib;

namespace FilmStock.Data
{
    public class DbInitializer
    {
        private FilmContext _db;
        public DbInitializer(FilmContext context)
        {
            _db = context;
        }
        public async Task Initialize()
        {
            _db.Database.EnsureCreated();
            await GetData();
            await _db.SaveChangesAsync();
        }
        public async Task GetData()
        {
            var apiLib = new ApiLib("k_i94oi014");
            var response = await apiLib.Top250MoviesAsync();
            PopulateMemory(response, ContentType.movie);
            response = await apiLib.Top250TVsAsync();
            PopulateMemory(response, ContentType.series);
        }

        private void PopulateMemory(IMDbApiLib.Models.Top250Data data, ContentType type)
        {
            foreach (var movie in data.Items)
            {
                //_db.Movies.Add(Convert(movie, type));
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