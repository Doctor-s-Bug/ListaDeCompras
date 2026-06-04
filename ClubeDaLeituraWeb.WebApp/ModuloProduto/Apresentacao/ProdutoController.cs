using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao.Views;

public class ProdutoController : Controller
{
    private readonly IRepositorioProduto repositorioProduto;

    public ProdutoController(IRepositorioProduto repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
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
}
