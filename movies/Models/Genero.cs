using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class Genero
    {
        public int Codigo { get; set; }

        [Required]
        public string? Nome { get; set; }
    }
}
