using FuscaFilmes.Domain.Entities;

namespace FuscaFilmes.Repo.Contratos;

public interface IFilmeRepository
{
    void Add(Filme filme);
    void Update(Filme filme);
    void Delete(int filmeId);
    bool SaveChanges();
}
