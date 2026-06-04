using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCaixa.Infra;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;

var builder = WebApplication.CreateBuilder(args);

#region Configuração de Serviços de Infraestrutura

builder.Services.AddScoped(provider =>
{
    ContextoJson contextoJson = new ContextoJson();

    contextoJson.Carregar();

    return contextoJson;
});
//dps tem que fazer a injeção de dependencia

builder.Services.AddScoped<IRepositorioCaixa, RepositorioCaixaEmArquivo>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmArquivo>();
builder.Services.AddScoped<ServicoCategoria>(); 
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
