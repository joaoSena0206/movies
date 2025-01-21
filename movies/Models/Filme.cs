using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Filme
{
    [Key]
    public int Codigo { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string NomeOriginal { get; set; }

    [Required]
    [StringLength(255)]
    public string FaixaEtaria { get; set; }

    [Required]
    public string Sinopse { get; set; }

    [Required]
    [ForeignKey("Diretor")]
    public int CodigoDiretor { get; set; }
    public Diretor? Diretor { get; set; }

    [Required]
    public ICollection<Genero> Generos { get; set; }

    public int AnoLancamento { get; set; }
    public TimeSpan Duracao { get; set; }
    public decimal Avaliacao { get; set; }

    public Filme()
    {
        this.Nome = string.Empty;
        this.NomeOriginal = string.Empty;
        this.FaixaEtaria = string.Empty;
        this.Sinopse = string.Empty;
        this.Generos = new List<Genero>();
    }
}
