using System;
using System.Threading.Tasks;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{
    public Context Context { get; } = _context;
    
    public async Task<List<Diretor>> GetDiretoresAssync()
    {
        return await Context.Diretores.Include(diretor => diretor.Filmes).ToListAsync();
    }

    public async Task<Diretor> GetDiretorByNameAssync(string name)
    {
        return await Context.Diretores
            .Include(diretor => diretor.Filmes)
            .FirstOrDefaultAsync(diretor => diretor.Name.Contains(name))
            ?? new Diretor() { Id = 999, Name = "Marina" };
    }

    public async Task<List<Diretor>> GetDiretoresByIdAssync(int id)
    {
        return await Context.Diretores
            .Where(diretor => diretor.Id == id)
            .Include(diretor => diretor.Filmes)
            .ToListAsync();
    }

    public async Task<DiretorDetalhe> GetDiretorDetalheAssync(int id)
    {
        var diretor = await Context.Diretores
            .Include(diretor => diretor.DiretorDetalhe)
            .FirstOrDefaultAsync(d => d.Id == id);

        return diretor?.DiretorDetalhe ?? new DiretorDetalhe()
        {
            Id = 999999, 
            Biografia = "Não ENcontrada", 
            DataNascimento = new DateTime(1900, 01, 01)
        };
    }
    public async Task AddAssync(Diretor diretor)
    {
        await Context.Diretores.AddAsync(diretor);
    }

    public async Task DeleteAssync(int diretorId)
    {
        var diretor = await Context.Diretores.FindAsync(diretorId);

        if (diretor != null)
            Context.Remove(diretor);
    }

    public async Task UpdateAssync(Diretor diretorNovo)
    {
        var diretor = await Context.Diretores.FindAsync(diretorNovo.Id);

        if (diretor != null)
        {
            diretor.Name = diretorNovo.Name;
            if (diretorNovo.Filmes.Count > 0)
            {
                diretor.Filmes.Clear();
                foreach (var filme in diretorNovo.Filmes)
                {
                    diretor.Filmes.Add(filme);
                }
            }
        }
    }

    public async Task<bool> SaveChangesAssync()
    {
        return (await Context.SaveChangesAsync()) > 0;
    }

}
