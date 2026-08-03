using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Sql;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Infra;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        //add no services o dbContext
        services.AddDbContext<ListaDeComprasDbContext>(opt =>
        {
            //busca a string do caminho do Banco de Dados e faz a validacao
            string? connectionString = configuration.GetConnectionString("SqlServer");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServer\" não foi encontrada."
                );
            }

            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();

        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
        services.AddScoped<IRepositorioProduto, RepositorioProdutoEmOrm>();
        // services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
        // services.AddScoped<IRepositorioListaDeCompra, RepositorioListaDeCompraEmArquivo>();
    }
}
