using System.Text.Json.Serialization;
using FuscaFilmes.API.DbContexts;
using FuscaFilmes.API.Entities;
using FuscaFilmes.API.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:FuscaFilmesStr"])
    .LogTo(Console.WriteLine, LogLevel.Information)
);

// using (var context = new Context())
// {
//     context.Database.EnsureCreated();
// }

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/diretores", (Context context) =>
{
    return context.Diretores.Include(diretor => diretor.Filmes).ToList();
})
.WithOpenApi();

app.MapGet("/diretores/agregacao/{name}", (Context context, string name) =>
{
    // return context.Diretores
    //     .Include(diretor => diretor.Filmes)
    //     //.Select(diretor => diretor.Name)
    //     .FirstOrDefault(diretor => diretor.Name.Contains(name))
    //     ?? new Diretor(){Id = 999, Name = "Marina"};

    return context.Diretores
        .Include(diretor => diretor.Filmes)
        .Select(diretor => diretor.Name)
        .FirstOrDefault()
        ?? "Marina";
})
.WithOpenApi();

app.MapGet("/diretores/where/{id}", (Context context, int id) =>
{
    return context.Diretores
        .Where(diretor => diretor.Id == id)
        .Include(diretor => diretor.Filmes)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmes/", (Context context) =>
{
    return context.Filmes
        .Include(filme => filme.Diretor)
        // .OrderBy(filme => filme.Ano)
        .OrderByDescending(filme => filme.Ano)
        // .ThenBy(filme => filme.Titulo)
        .ThenByDescending(filme => filme.Titulo)
        .ToList();
})
.WithOpenApi();

app.MapGet("/filmes/{id}", (Context context, int id) =>
{
    return context.Filmes
        .Where(filme => filme.Id == id)
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapGet("/filmesEFFunctions/byName/{id}", (Context context, string titulo) =>
{
    // return context.Filmes
    //     .Where(filme => filme.Titulo.Contains(titulo))
    //     .Include(filme => filme.Diretor).ToList();

    return context.Filmes
        .Where(filme => EF.Functions.Like(filme.Titulo, $"%{titulo}%"))
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapGet("/filmesLinQ/byName/{id}", (Context context, string titulo) =>
{
    return context.Filmes
        .Where(filme => filme.Titulo.Contains(titulo))
        .Include(filme => filme.Diretor).ToList();
})
.WithOpenApi();

app.MapPost("/diretores", (Diretor diretor, Context context) =>
{
    context.Diretores.Add(diretor);
    context.SaveChanges();
})
.WithOpenApi();

app.MapPut("/diretores/{diretorId}", (int diretorId, Diretor diretorNovo, Context context) =>
{
    var diretor = context.Diretores.Find(diretorId);

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

    context.SaveChanges();
})
.WithOpenApi();

app.MapDelete("/filmes/{filmeId}", (int filmeId, Context context) =>
{
   context.Filmes
    .Where(filme => filme.Id == filmeId)
    .ExecuteDelete<Filme>();
})
.WithOpenApi();

app.MapPatch("/filmesUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
    var filme = context.Filmes.Find(filmeUpdate.Id);

    if(filme == null)
    {
        return Results.NotFound("Filme não encontrado!");
    }

    filme.Titulo = filmeUpdate.Titulo;
    filme.Ano = filmeUpdate.Ano;

    context.Filmes.Update(filme);
    context.SaveChanges();
    
    return Results.Ok($"Filme Id: {filmeUpdate.Id}, Atualizado com sucesso!");
})
.WithOpenApi();

app.MapPatch("/filmesExecuteUpdate", (Context context, FilmeUpdate filmeUpdate) =>
{
   var linhasAfetadas = context.Filmes
    .Where(filme => filme.Id == filmeUpdate.Id)
    .ExecuteUpdate(setter => setter
        .SetProperty(f => f.Titulo, filmeUpdate.Titulo)
        .SetProperty(f => f.Ano, filmeUpdate.Ano)
    );

    if(linhasAfetadas > 0)
    {
        return Results.Ok($"Total de linhas afetadas: {linhasAfetadas}");
    }
    else{
        return Results.NoContent();
    }
})
.WithOpenApi();

app.MapDelete("/diretores/{diretorId}", (int diretorId, Context context) =>
{
    var diretor = context.Diretores.Find(diretorId);

    if (diretor != null)
        context.Remove(diretor);

    context.SaveChanges();
})
.WithOpenApi();

app.Run();