using FilmStock.Models;
using Newtonsoft.Json;

namespace FilmStock.Utilities
{
    public class Util
    {
		internal async void GetTopMovies()
		{
			
		}

		internal List<MovieModel> ConvertJSONToCollection(string jsonData)
        {
			var result = JsonConvert.DeserializeObject<MovieListModel>(jsonData);
			return result.AllMovies;
        }
    }
}
