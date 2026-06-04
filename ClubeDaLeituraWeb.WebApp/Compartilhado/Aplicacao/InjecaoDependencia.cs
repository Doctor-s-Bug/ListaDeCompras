using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddAplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoCategoria>();
    }
}
