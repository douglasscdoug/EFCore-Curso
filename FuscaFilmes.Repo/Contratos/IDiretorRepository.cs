using FuscaFilmes.Domain.Entities;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorRepository
{
    Task<List<Diretor>> GetDiretoresAssync();
    Task<Diretor> GetDiretorByNameAssync(string name);
    Task<List<Diretor>> GetDiretoresByIdAssync(int id);
    Task<DiretorDetalhe> GetDiretorDetalheAssync(int id);
    Task AddAssync(Diretor diretor);
    Task UpdateAssync(Diretor diretor);
    Task DeleteAssync(int diretorId);
    Task<bool> SaveChangesAssync();
}
