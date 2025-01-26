using FuscaFilmes.API.EndpointsHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointFilmes
{
    public static void FilmesEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/filmes/", FilmesHandlers.GetFilmesAssync)
            .WithOpenApi();

        app.MapGet("/filmes/{id}", FilmesHandlers.GetFilmeByIdAssync)
            .WithOpenApi();

        app.MapGet("/filmesEFFunctions/byName/{titulo}", FilmesHandlers.GetFilmeEFFunctionsByTituloAssync)
            .WithOpenApi();

        app.MapGet("/filmesContains/byName/{titulo}", FilmesHandlers.GetFilmesContainsByTituloAssync)
            .WithOpenApi();

        app.MapDelete("/filmes/{filmeId}", FilmesHandlers.ExecuteDeleteFilmeAssync)
            .WithOpenApi();

        app.MapPatch("/filmesUpdate", FilmesHandlers.UpdateFilmeAssync)
            .WithOpenApi();

        app.MapPatch("/filmesExecuteUpdate", FilmesHandlers.ExecuteUpdateFIlmeAssync)
            .WithOpenApi();
    }
}
