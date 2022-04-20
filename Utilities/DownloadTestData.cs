namespace FilmStock.Utilities
{
    public class DownloadTestData
    {
		public async void Top250Movies()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-scraper.p.rapidapi.com/top250"),
				Headers =
	{
		{ "X-RapidAPI-Host", "imdb-scraper.p.rapidapi.com" },
		{ "X-RapidAPI-Key", "9116f684c8msh66dc01697128539p1485f7jsn12ff8745bba9" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				Console.WriteLine(body);
			}
		}
    }
}
