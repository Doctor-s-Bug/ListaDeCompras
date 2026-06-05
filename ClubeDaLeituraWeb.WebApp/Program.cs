using ClubeDaLeituraWeb.WebApp.Compartilhado.Aplicacao;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Apresentacao;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraRepositories();
builder.Services.AddAplicationServices();
builder.Services.AddPresentation();

var app = builder.Build();

// Configuração de Middlewares
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
