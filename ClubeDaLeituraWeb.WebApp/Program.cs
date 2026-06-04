using ClubeDaLeituraWeb.WebApp.Compartilhado.Aplicacao;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

var builder = WebApplication.CreateBuilder(args);

#region Configuração de Serviços de Infraestrutura

builder.Services.AddScoped(provider =>
{
    ContextoJson contextoJson = new ContextoJson();

    contextoJson.Carregar();

    return contextoJson;
});
//dps tem que fazer a injeção de dependencia

builder.Services.AddInfraRepositories();
builder.Services.AddAplicationServices();
#endregion

#region Configuração do MVC

builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
    // Reseta a configuração padrão do MVC
    options.ViewLocationFormats.Clear();

    // Localização das Views dos módulos: /ModuloCaixa/Apresentacao/Views/Listar.cshtml
    options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

    // Localização das Views compartilhadas: /Compartilhado/Apresentacao/Views/_Layout.cshtml
    options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
});

#endregion

var app = builder.Build();

// Configuração de Middlewares
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
