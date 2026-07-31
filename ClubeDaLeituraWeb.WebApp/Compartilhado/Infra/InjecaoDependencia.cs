using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Infra;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ListaDeComprasDbContext>(opt =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServer\" não foi encontrada."
                );
            }

            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioProduto, RepositorioProdutoEmArquivo>();
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        services.AddScoped<IRepositorioListaDeCompra, RepositorioListaDeCompraEmArquivo>();
    }
}
