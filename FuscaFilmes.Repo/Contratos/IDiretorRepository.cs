using FuscaFilmes.Domain.Entities;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorRepository
{
    List<Diretor> GetDiretores();
    Diretor GetDiretorByName(string name);
    List<Diretor> GetDiretoresById(int id);
    DiretorDetalhe GetDiretorDetalhe(int id);
    void Add(Diretor diretor);
    void Update(Diretor diretor);
    void Delete(int diretorId);
    bool SaveChanges();
}
