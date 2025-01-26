using System.ComponentModel.DataAnnotations;

namespace FuscaFilmes.Domain.Entities;

public class Filme
{
    public int Id { get; set; }

    [Required]
    [MaxLength]
    public string Titulo { get; set; } = string.Empty;

    [Range(1900, 2050)]
    public int Ano { get; set; }

    public decimal Orcamento { get; set; }
    public ICollection<Diretor> Diretores { get; set; } = null!;
    public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;
}
