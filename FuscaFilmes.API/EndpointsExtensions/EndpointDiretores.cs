using FuscaFilmes.API.EndpointsHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointDiretores
{
    public static void DiretoresEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/diretores", DiretoresHandlers.GetDiretoresAssync)
            .WithOpenApi();

        app.MapGet("/diretores/agregacao/{name}", DiretoresHandlers.GetDiretorByNameAssync)
            .WithOpenApi();

        app.MapGet("/diretores/where/{id}", DiretoresHandlers.GetDiretoresByIdAssync)
            .WithOpenApi();

        app.MapGet("/diretores/diretorDetalhe/{id}", DiretoresHandlers.GetDiretorDetalheAssync)
            .WithOpenApi();

        app.MapPost("/diretores", DiretoresHandlers.AddDiretorAssync)
            .WithOpenApi();

        app.MapPut("/diretores", DiretoresHandlers.UpdateDiretorAssync)
            .WithOpenApi();

        app.MapDelete("/diretores/{diretorId}", DiretoresHandlers.DeleteDiretorAssync)
            .WithOpenApi();
    }
}
