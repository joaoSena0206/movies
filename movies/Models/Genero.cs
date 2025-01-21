using System.ComponentModel.DataAnnotations;

public class Genero
{
    [Key]
    public int Codigo { get; set; }

    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }
}
