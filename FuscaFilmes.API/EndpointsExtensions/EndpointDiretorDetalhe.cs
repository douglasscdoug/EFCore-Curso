using FuscaFilmes.API.EndpointsHandlers;

namespace FuscaFilmes.API.EndpointsExtensions;

public static class EndpointDiretorDetalhe
{
    public static void DiretorDetalheEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/diretorDetalhe", DiretorDetalheHandlers.GetDiretorDetalhe).WithOpenApi();

        app.MapPost("/diretorDetalhe", DiretorDetalheHandlers.AddDiretorDetalhe).WithOpenApi();

        app.MapPut("/diretorDetalhe", DiretorDetalheHandlers.UpdateDiretorDetalhe).WithOpenApi();

        app.MapDelete("/diretorDetalhe/{diretorDetalheId}", DiretorDetalheHandlers.DeleteDiretorDetalhe).WithOpenApi();
    }
}
