using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;

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
        services.AddScoped<IRepositorioCaixa, RepositorioCaixaEmArquivo>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
    }
}
