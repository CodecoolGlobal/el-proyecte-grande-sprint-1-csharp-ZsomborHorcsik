using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmStock.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmStock.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Movie>? Movies{ get; set;}
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
    }
}
