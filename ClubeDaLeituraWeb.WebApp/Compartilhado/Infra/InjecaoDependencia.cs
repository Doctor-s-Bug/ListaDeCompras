using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Infra;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            ContextoJson contextoJson = new ContextoJson();

            contextoJson.Carregar();

            return contextoJson;
        });
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioListaDeCompra, RepositorioListaDeCompraEmArquivo>();
    }
}
