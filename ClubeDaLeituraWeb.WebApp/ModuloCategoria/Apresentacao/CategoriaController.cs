using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using Microsoft.AspNetCore.Mvc;
using static ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao.CategoriaViewModels;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IRepositorioCategoria repositorioCategoria;

    public CategoriaController(ServicoCategoria servicoCategoria, IRepositorioCategoria repositorioCategoria)
    {
        this.servicoCategoria = servicoCategoria;
        this.repositorioCategoria = repositorioCategoria;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        List<ListarCategoriaViewModels> listarVm = new();

        foreach (Categoria categoria in categorias)
        {
            ListarCategoriaViewModels vm = new(
                categoria.Id,
                categoria.Nome,
                categoria.Cor.ToString()
            );
            listarVm.Add(vm);
        }

        return View(listarVm);
    }
}
