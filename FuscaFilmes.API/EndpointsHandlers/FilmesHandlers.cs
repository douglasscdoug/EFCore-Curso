using System.Threading.Tasks;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Models;
using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.EndpointsHandlers;

public static class FilmesHandlers
{
    public static async Task<List<Filme>> GetFilmesAssync(Context context)
    {
        return await context.Filmes
            .Include(filme => filme.Diretores)
            // .OrderBy(filme => filme.Ano)
            .OrderByDescending(filme => filme.Ano)
            // .ThenBy(filme => filme.Titulo)
            .ThenByDescending(filme => filme.Titulo)
            .ToListAsync();
    }

    public static async Task<List<Filme>> GetFilmeByIdAssync(Context context, int id)
    {
        return await context.Filmes
            .Where(filme => filme.Id == id)
            .Include(filme => filme.Diretores)
            .ToListAsync();
    }

    public static async Task<List<Filme>> GetFilmeEFFunctionsByTituloAssync(Context context, string titulo)
    {
        return await context.Filmes
            .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
            .Include(filme => filme.Diretores)
            .ToListAsync();
    }

    public static async Task<List<Filme>> GetFilmesContainsByTituloAssync(Context context, string titulo)
    {
        return await context.Filmes
            .Where(filme => filme.Titulo.Contains(titulo))
            .Include(filme => filme.Diretores)
            .ToListAsync();
    }

    public static async Task ExecuteDeleteFilmeAssync(int filmeId, Context context)
    {
        await context.Filmes
         .Where(filme => filme.Id == filmeId)
         .ExecuteDeleteAsync<Filme>();
    }

    public static async Task<IResult> UpdateFilmeAssync(Context context, FilmeUpdate filmeUpdate)
    {
        var filme = await context.Filmes.FindAsync(filmeUpdate.Id);

        if (filme == null)
        {
            return Results.NotFound("Filme não encontrado!");
        }

        filme.Titulo = filmeUpdate.Titulo;
        filme.Ano = filmeUpdate.Ano;

        context.Filmes.Update(filme);
        await context.SaveChangesAsync();

        return Results.Ok($"Filme Id: {filmeUpdate.Id}, Atualizado com sucesso!");
    }

    public static async Task<IResult> ExecuteUpdateFIlmeAssync(Context context, FilmeUpdate filmeUpdate)
    {
        var linhasAfetadas = await context.Filmes
         .Where(filme => filme.Id == filmeUpdate.Id)
         .ExecuteUpdateAsync(setter => setter
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
