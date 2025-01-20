using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class FilmeGenero
    {
        [Required]
        public Filme? Filme { get; set; }

        [Required]
        public Genero? Genero { get; set; }

        public FilmeGenero()
        {

        }
    }
}
