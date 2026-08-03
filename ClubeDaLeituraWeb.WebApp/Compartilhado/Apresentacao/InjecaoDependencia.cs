using ClubeDaLeituraWeb.WebApp.Compartilhado.Apresentacao.Mapping;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Apresentacao;

public static class InjecaoDependencia
{
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
    {
        // Reseta a configuração padrão do MVC
        options.ViewLocationFormats.Clear();

        // Localização das Views dos módulos: /ModuloCaixa/Apresentacao/Views/Listar.cshtml
        options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

        // Localização das Views compartilhadas: /Compartilhado/Apresentacao/Views/_Layout.cshtml
        options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
    });

        services.AddAutoMapper(mapperConfig =>
        {
            AutoMapperOptions autoMapperOptions = configuration
                .GetSection(AutoMapperOptions.SectionName)
                .Get<AutoMapperOptions>() ?? new AutoMapperOptions();

            string? licenseKey = autoMapperOptions.LicenseKey;

            if (!string.IsNullOrWhiteSpace(licenseKey))
                mapperConfig.LicenseKey = licenseKey;

            mapperConfig.AddMaps(typeof(Program));
        });
    }
}
