namespace FuscaFilmes.Domain.Entities;

public class Diretor
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Filme> Filmes { get; set; } = null!;
    public ICollection<DiretorFilme> DiretoresFilmes { get; set; } = null!;
    public DiretorDetalhe? DiretorDetalhe { get; set; }
}
