using FuscaFilmes.API.DbContexts;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using Microsoft.AspNetCore.Http;

namespace FuscaFilmes.Repo;

public class DiretorDetalheRepository(Context _context) : IDiretorDetalheRepository
{
    public Context Context { get; } = _context;
    public List<DiretorDetalhe> GetDiretorDetalhe()
    {
        return Context.DiretorDetalhe.ToList();
    }
    public IResult Add(DiretorDetalhe diretorDetalhe)
    {
        if (diretorDetalhe == null)
        {
            return Results.BadRequest("O Objeto DiretorDetalhe é inválid!");
        }
        var diretorExiste = Context.Diretores.Find(diretorDetalhe.DiretorId);
        var diretorDDetalheExiste = Context.DiretorDetalhe.FirstOrDefault(d => d.DiretorId == diretorDetalhe.DiretorId);

        if (diretorExiste == null)
        {
            return Results.NotFound("Diretor Id Não encontrado");
        }
        else if (diretorDDetalheExiste != null)
        {
            return Results.BadRequest($"Já existe uma descrição cadastrada para o diretor Id: {diretorDetalhe.DiretorId}");
        }

        Context.Add(diretorDetalhe);
        Context.SaveChanges();
        return Results.Ok($"Detalhes do diretor Id: {diretorDetalhe.DiretorId}, Cadastrado com sucesso!");

    }

    public IResult Delete(int diretorDetalheId)
    {
        var diretorDetalhe = Context.DiretorDetalhe.Find(diretorDetalheId);

        if (diretorDetalhe != null)
        {
            Context.Remove(diretorDetalhe);
            Context.SaveChanges();
            return Results.Ok($"Detalhes do diretor Id: {diretorDetalhe.DiretorId}, removido com sucesso!");
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return Results.NotFound($"Diretor Id: {diretorDetalhe.DiretorId}, não localizado!");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public IResult Update(DiretorDetalhe diretorDetalheNovo)
    {
        var diretorDetalhe = Context.DiretorDetalhe.Find(diretorDetalheNovo.Id);
        var validaDIretorExiste = Context.Diretores.Find(diretorDetalheNovo.DiretorId);
        if (diretorDetalhe == null)
        {
            return Results.NotFound($"Detalhes do diretor Id: {diretorDetalheNovo.Id} não encontrado, verifique e tente novamente!");
        }
        else if(validaDIretorExiste == null)
        {
            return Results.NotFound($"Diretor Id: {diretorDetalhe.DiretorId} não encontrado.");
        }
        diretorDetalhe.Biografia = diretorDetalheNovo.Biografia;
        diretorDetalhe.DataNascimento = diretorDetalheNovo.DataNascimento;
        diretorDetalhe.DiretorId = diretorDetalheNovo.DiretorId;
        Context.Update(diretorDetalhe);
        Context.SaveChanges();
        return Results.Ok($"Detalhe do diretor Id: {diretorDetalheNovo.Id}, Alterado com sucesso.");

    }
    public bool SaveChanges()
    {
        return Context.SaveChanges() > 0;
    }
}
