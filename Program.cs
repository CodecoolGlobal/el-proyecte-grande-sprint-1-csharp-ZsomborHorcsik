namespace FilmStock
{
    public static class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            Startup startup = new(builder);
        }
    }
}