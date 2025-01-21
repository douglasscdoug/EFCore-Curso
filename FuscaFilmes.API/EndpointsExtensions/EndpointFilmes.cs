using FuscaFilmes.API.EndpointsHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointFilmes
{
    public static void FilmesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/filmes/", FilmesHandlers.GetFilmes).WithOpenApi();

        app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeById).WithOpenApi();

        app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmesHandlers.GetFilmeEFFunctionsByTitulo).WithOpenApi();

        app.MapGet("/filmesContains/byName/{titulo}", FilmesHandlers.GetFilmesContainsByTitulo).WithOpenApi();

        app.MapDelete("/filmes/{filmeId}", FilmesHandlers.ExecuteDeleteFilme).WithOpenApi();

        app.MapPatch("/filmesUpdate", FilmesHandlers.UpdateFilme).WithOpenApi();

        app.MapPatch("/filmesExecuteUpdate", FilmesHandlers.ExecuteUpdateFIlme).WithOpenApi();
    }
}
