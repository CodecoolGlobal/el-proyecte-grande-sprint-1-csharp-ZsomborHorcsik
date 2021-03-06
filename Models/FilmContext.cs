using FilmStock.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmStock.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Collection>? Collection { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
    }
}
