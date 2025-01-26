using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;

namespace FuscaFilmes.API.EndpointsHandlers;

public static class DiretoresHandlers
{
    public static List<Diretor> GetDiretores(IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretores();
    }

    public static Diretor GetDiretorByName(IDiretorRepository diretorRepository, string name)
    {
        return diretorRepository.GetDiretorByName(name);
    }

    public static List<Diretor> GetDiretoresById(IDiretorRepository diretorRepository, int id)
    {
        return diretorRepository.GetDiretoresById(id);
    }

    public static DiretorDetalhe GetDiretorDetalhe(int id, IDiretorRepository diretorRepository)
    {
        return diretorRepository.GetDiretorDetalhe(id);
    }

    public static void AddDiretor(Diretor diretor, IDiretorRepository diretorRepository)
    {
        diretorRepository.Add(diretor);
        diretorRepository.SaveChanges();
    }

    public static void UpdateDiretor(Diretor diretorNovo, IDiretorRepository diretorRepository)
    {
        diretorRepository.Update(diretorNovo);
        diretorRepository.SaveChanges();
    }

    public static void DeleteDiretor(int diretorId, IDiretorRepository diretorRepository)
    {
        diretorRepository.Delete(diretorId);
        diretorRepository.SaveChanges();
    }
}
