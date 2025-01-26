using FuscaFilmes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuscaFilmes.API.DbContexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Diretor> Diretores { get; set; }
    public DbSet<DiretorFilme> DiretoresFilmes { get; set; }
    public DbSet<DiretorDetalhe> DiretorDetalhe { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diretor>()
            .HasMany(d => d.Filmes)
            .WithMany(f => f.Diretores)
            .UsingEntity<DiretorFilme>(
                df => df.HasOne<Filme>(e => e.Filme)
                        .WithMany(e => e.DiretoresFilmes),
                df => df.HasOne<Diretor>(e => e.Diretor)
                        .WithMany(e => e.DiretoresFilmes)
            );

        modelBuilder.Entity<Diretor>()
            .HasOne(d => d.DiretorDetalhe)
            .WithOne(d => d.Diretor)
            .HasForeignKey<DiretorDetalhe>(dd => dd.DiretorId);

        modelBuilder.Entity<Diretor>().HasData(
            new Diretor { Id = 1, Name = "Christopher Nolan" },
            new Diretor { Id = 2, Name = "Quentin Tarantino" },
            new Diretor { Id = 3, Name = "Steven Spielberg" },
            new Diretor { Id = 4, Name = "Martin Scorsese" },
            new Diretor { Id = 5, Name = "Ridley Scott" }
        );

        modelBuilder.Entity<DiretorDetalhe>().HasData(
            new DiretorDetalhe { Id = 1, DiretorId = 1, Biografia = "Biografia do Christopher Nolan", DataNascimento = new DateTime(1970, 7, 30)},
            new DiretorDetalhe { Id = 2, DiretorId = 2, Biografia = "Biografia do Quentin Tarantino", DataNascimento = new DateTime(1963, 3, 27)}
        );

        modelBuilder.Entity<Filme>().HasData(
            new Filme { Id = 1, Titulo = "Inception", Ano = 2010},
            new Filme { Id = 2, Titulo = "The Dark Knight", Ano = 2008},
            new Filme { Id = 3, Titulo = "Pulp Fiction", Ano = 1994},
            new Filme { Id = 4, Titulo = "Kill Bill: Vol. 1", Ano = 2003},
            new Filme { Id = 5, Titulo = "Schindler's List", Ano = 1993},
            new Filme { Id = 6, Titulo = "Jurassic Park", Ano = 1993},
            new Filme { Id = 7, Titulo = "Taxi Driver", Ano = 1976},
            new Filme { Id = 8, Titulo = "Goodfellas", Ano = 1990},
            new Filme { Id = 9, Titulo = "Gladiator", Ano = 2000},
            new Filme { Id = 10, Titulo = "Alien", Ano = 1979}
        );

        modelBuilder.Entity<DiretorFilme>().HasData(
            new {DiretorId = 1, FilmeId = 1},
            new {DiretorId = 1, FilmeId = 2},
            new {DiretorId = 2, FilmeId = 3},
            new {DiretorId = 2, FilmeId = 4},
            new {DiretorId = 3, FilmeId = 5},
            new {DiretorId = 3, FilmeId = 6},
            new {DiretorId = 4, FilmeId = 7},
            new {DiretorId = 4, FilmeId = 8},
            new {DiretorId = 5, FilmeId = 9},
            new {DiretorId = 5, FilmeId = 10}
        );
    }
}
