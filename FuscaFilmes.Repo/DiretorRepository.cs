using System;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.Domain.Entities;
using FuscaFilmes.Repo.Contratos;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.Repo;

public class DiretorRepository(Context _context) : IDiretorRepository
{
    public Context Context { get; } = _context;
    
    public List<Diretor> GetDiretores()
    {
        return Context.Diretores.Include(diretor => diretor.Filmes).ToList();
    }

    public Diretor GetDiretorByName(string name)
    {
        return Context.Diretores
            .Include(diretor => diretor.Filmes)
            .FirstOrDefault(diretor => diretor.Name.Contains(name))
            ?? new Diretor() { Id = 999, Name = "Marina" };
    }

    public List<Diretor> GetDiretoresById(int id)
    {
        return Context.Diretores
            .Where(diretor => diretor.Id == id)
            .Include(diretor => diretor.Filmes)
            .ToList();
    }
    public void Add(Diretor diretor)
    {
        Context.Diretores.Add(diretor);
    }

    public void Delete(int diretorId)
    {
        var diretor = Context.Diretores.Find(diretorId);

        if (diretor != null)
            Context.Remove(diretor);
    }

    public void Update(Diretor diretorNovo)
    {
        var diretor = Context.Diretores.Find(diretorNovo.Id);

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

    public bool SaveChanges()
    {
        return Context.SaveChanges() > 0;
    }

}
