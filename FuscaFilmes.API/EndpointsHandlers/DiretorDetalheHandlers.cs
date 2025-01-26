using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;

namespace FuscaFilmes.API.EndpointsHandlers;

public static class DiretorDetalheHandlers
{
    public static List<DiretorDetalhe> GetDiretorDetalhe(IDiretorDetalheRepository diretorDetalheRepository)
    {
        return diretorDetalheRepository.GetDiretorDetalhe();
    }

    public static IResult AddDiretorDetalhe(IDiretorDetalheRepository diretorDetalheRepository, DiretorDetalhe diretorDetalhe)
    {
        var result = diretorDetalheRepository.Add(diretorDetalhe);
        return result;
    }

    public static IResult DeleteDiretorDetalhe(IDiretorDetalheRepository diretorDetalheRepository, int diretorDetalheId)
    {
        var result = diretorDetalheRepository.Delete(diretorDetalheId);
        return result;
    }

    public static IResult UpdateDiretorDetalhe(IDiretorDetalheRepository diretorDetalheRepository, DiretorDetalhe diretorDetalhe)
    {
        var result = diretorDetalheRepository.Update(diretorDetalhe);
        return result;
    }
}
