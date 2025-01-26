using System.Threading.Tasks;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;

namespace FuscaFilmes.API.EndpointsHandlers;

public static class DiretoresHandlers
{
    public static async Task<List<Diretor>> GetDiretoresAssync(IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretoresAssync();
    }

    public static async Task<Diretor> GetDiretorByNameAssync(IDiretorRepository diretorRepository, string name)
    {
        return await diretorRepository.GetDiretorByNameAssync(name);
    }

    public static async Task<List<Diretor>> GetDiretoresByIdAssync(IDiretorRepository diretorRepository, int id)
    {
        return await diretorRepository.GetDiretoresByIdAssync(id);
    }

    public static async Task<DiretorDetalhe> GetDiretorDetalheAssync(int id, IDiretorRepository diretorRepository)
    {
        return await diretorRepository.GetDiretorDetalheAssync(id);
    }

    public static async Task AddDiretorAssync(Diretor diretor, IDiretorRepository diretorRepository)
    {
        await diretorRepository.AddAssync(diretor);
        await diretorRepository.SaveChangesAssync();
    }

    public static async Task UpdateDiretorAssync(Diretor diretorNovo, IDiretorRepository diretorRepository)
    {
        await diretorRepository.UpdateAssync(diretorNovo);
        await diretorRepository.SaveChangesAssync();
    }

    public static async Task DeleteDiretorAssync(int diretorId, IDiretorRepository diretorRepository)
    {
        await diretorRepository.DeleteAssync(diretorId);
        await diretorRepository.SaveChangesAssync();
    }
}
