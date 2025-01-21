using System.ComponentModel.DataAnnotations;

namespace movies.Models
{
    public class Filme
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? NomeOriginal { get; set; }

        [Required]
        public int FaixaEtaria { get; set; }

        [Required]
        public string? Sinopse { get; set; }

        [Required]
        public Diretor? Diretor { get; set; }

        public int Codigo { get; set; }
        public int AnoLancamento { get; set; }
        public TimeSpan Duracao { get; set; }
        public decimal Avaliacao { get; set; }

        public Filme()
        {

        }
    }
}
