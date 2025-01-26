using FuscaFilmes.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FuscaFilmes.Repo.Contratos;

public interface IDiretorDetalheRepository
{
        List<DiretorDetalhe> GetDiretorDetalhe();
        IResult Add(DiretorDetalhe diretorDetalhe);
        IResult Update(DiretorDetalhe diretorDetalhe);
        IResult Delete(int diretorDetalheId);
        bool SaveChanges();
}

