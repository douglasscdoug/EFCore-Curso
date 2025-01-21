using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointsHandlers;

public static class FilmesHandlers
{
    public static List<Filme> GetFilmes(Context context)
    {
        return context.Filmes
            .Include(filme => filme.Diretor)
            // .OrderBy(filme => filme.Ano)
            .OrderByDescending(filme => filme.Ano)
            // .ThenBy(filme => filme.Titulo)
            .ThenByDescending(filme => filme.Titulo)
            .ToList();
    }

    public static List<Filme> GetFilmeById(Context context, int id)
    {
        return context.Filmes
            .Where(filme => filme.Id == id)
            .Include(filme => filme.Diretor).ToList();
    }

    public static List<Filme> GetFilmeEFFunctionsByTitulo(Context context, string titulo)
    {
        return context.Filmes
            .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
            .Include(filme => filme.Diretor).ToList();
    }

    public static List<Filme> GetFilmesContainsByTitulo(Context context, string titulo)
    {
        return context.Filmes
            .Where(filme => filme.Titulo.Contains(titulo))
            .Include(filme => filme.Diretor).ToList();
    }

    public static void ExecuteDeleteFilme(int filmeId, Context context)
    {
        context.Filmes
         .Where(filme => filme.Id == filmeId)
         .ExecuteDelete<Filme>();
    }

    public static IResult UpdateFilme(Context context, FilmeUpdate filmeUpdate)
    {
        var filme = context.Filmes.Find(filmeUpdate.Id);

        if (filme == null)
        {
            return Results.NotFound("Filme não encontrado!");
        }

        filme.Titulo = filmeUpdate.Titulo;
        filme.Ano = filmeUpdate.Ano;

        context.Filmes.Update(filme);
        context.SaveChanges();

        return Results.Ok($"Filme Id: {filmeUpdate.Id}, Atualizado com sucesso!");
    }

    public static IResult ExecuteUpdateFIlme(Context context, FilmeUpdate filmeUpdate)
    {
        var linhasAfetadas = context.Filmes
         .Where(filme => filme.Id == filmeUpdate.Id)
         .ExecuteUpdate(setter => setter
             .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
             .SetProperty(f => f.Ano, filmeUpdate.Ano)
         );

        if (linhasAfetadas > 0)
        {
            return Results.Ok($"Total de linhas afetadas: {linhasAfetadas}");
        }
        else
        {
            return Results.NoContent();
        }
    }
}
