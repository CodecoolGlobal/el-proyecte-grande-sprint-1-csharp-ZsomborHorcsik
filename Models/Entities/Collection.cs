using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStock.Models.Entities
{
    public class Collection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
