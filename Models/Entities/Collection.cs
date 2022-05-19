using FilmStock.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? Name { get; set; }
        public List<Movie>? Movies { get; set; }
    }

}