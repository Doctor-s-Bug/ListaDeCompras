using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using Microsoft.AspNetCore.Mvc;
using static ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao.CategoriaViewModels;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao.Views;

public class ProdutoController : Controller
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IRepositorioProduto repositorioProduto;

    public ProdutoController(IRepositorioProduto repositorioProduto, IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public ActionResult Listar()
    {
        List<Produto> ListaProdutos = repositorioProduto.SelecionarTodos();

        List<ListarProdutosViewModel> listarVm = new();

        foreach (Produto p in ListaProdutos)
        {
            ListarProdutosViewModel vm = new(
        p.Id,
        p.Nome,
        p.UnidadeMedida,
        p.PrecoAproximado,
        p.Categoria.Nome
        );

            listarVm.Add(vm);

        }

        return View(listarVm);
    }

    public ActionResult Cadastrar()
    {
        ViewBag.categoria = carregarCategoria();

        return View();
    }

    private List<MostrarCategoriaViewModel> carregarCategoria()
    {
        List<Categoria> listaCategoria = repositorioCategoria.SelecionarTodos();

        List<MostrarCategoriaViewModel> listarVm = new();

        foreach (Categoria p in listaCategoria)
        {
            MostrarCategoriaViewModel vm = new(
            p.Id,
            p.Nome
         );
            listarVm.Add(vm);
        }

        return listarVm;
    }
}
