using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Aplicacao;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoLista>();
    }
}
