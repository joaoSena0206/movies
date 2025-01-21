using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Diretor
{
    [Key]
    public int Codigo { get; set; }

    [Required]
    [StringLength(255)]
    public string Nome { get; set; }

    public Diretor()
    {
        this.Nome = string.Empty;
    }
}
