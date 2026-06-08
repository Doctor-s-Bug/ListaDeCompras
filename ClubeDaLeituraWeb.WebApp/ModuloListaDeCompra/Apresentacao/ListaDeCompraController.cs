using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public class ListaDeCompraController : Controller
{
    private readonly IRepositorioListaDeCompra repositorioListaDeCompra;
    private readonly IRepositorioProduto repositorioProduto;
    private readonly ServicoLista servicoLista;
    private readonly IMapper mapeador;

    public ListaDeCompraController(ServicoLista servicoLista, IRepositorioListaDeCompra repositorioListaDeCompra, IMapper mapeador, IRepositorioProduto repositorioProduto)
    {
        this.servicoLista = servicoLista;
        this.repositorioListaDeCompra = repositorioListaDeCompra;
        this.mapeador = mapeador;
        this.repositorioProduto = repositorioProduto;
    }

    public ActionResult Listar()
    {
        List<ListaDeCompra> listaDeCompras = repositorioListaDeCompra.SelecionarTodos();

        List<ListarListasViewModel> listarVms = mapeador.Map<List<ListarListasViewModel>>(listaDeCompras);

        return View(listarVms);
    }
    public ActionResult Cadastrar()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarListaViewModel cadastroVm)
    {
        ListaDeCompra listaDeCompra = new(cadastroVm.Nome);

        repositorioListaDeCompra.Cadastrar(listaDeCompra);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string id)
    {
        ListaDeCompra? listaDeCompra = repositorioListaDeCompra.SelecionarPorId(id);

        if (listaDeCompra == null)
            return RedirectToAction(nameof(Listar));

        ExcluirListaViewModel excluirVm = mapeador.Map<ExcluirListaViewModel>(listaDeCompra);

        return View(excluirVm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirListaViewModel excluirVm)
    {
        ListaDeCompra? listaDeCompra = repositorioListaDeCompra.SelecionarPorId(excluirVm.Id);

        if (listaDeCompra != null)
            repositorioListaDeCompra.Excluir(excluirVm.Id);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Editar(string id)
    {
        ListaDeCompra? listaDeCompra = repositorioListaDeCompra.SelecionarPorId(id);

        if (listaDeCompra == null)
            return RedirectToAction(nameof(Listar));

        EditarListaViewModel vmEditar = mapeador.Map<EditarListaViewModel>(listaDeCompra);

        return View(vmEditar);
    }
    [HttpPost]
    public ActionResult Editar(EditarListaViewModel vmEditar)
    {
        ListaDeCompra? listaDeCompra = repositorioListaDeCompra.SelecionarPorId(vmEditar.Id);

        if (listaDeCompra != null)
        {
            ListaDeCompra listaEditada = mapeador.Map<ListaDeCompra>(vmEditar);
            repositorioListaDeCompra.Editar(vmEditar.Id, listaEditada);
        }

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult MostrarLista(string id)
    {
        ListaDeCompra? listaDeCompra = repositorioListaDeCompra.SelecionarPorId(id);

        if (listaDeCompra == null)
            return RedirectToAction(nameof(Listar));

        List<ListarProdutoViewModel> produtosVm = mapeador.Map<List<ListarProdutoViewModel>>(listaDeCompra.ListaProdutos);

        ListarListasViewModel listarVm = new(listaDeCompra.Id, listaDeCompra.Nome, listaDeCompra.StatusLista, produtosVm, listaDeCompra.ValorTotal, listaDeCompra.DataCriacao.ToString("dd/MM/yyyy"));

        return View(listarVm);
    }
    public ActionResult Adicionar(string id)
    {
        ListaDeCompra? listaSelecionada = repositorioListaDeCompra.SelecionarPorId(id);

        List<ListarProdutoViewModel> itensProdutoProfile = [];

        ListarProdutoViewModel listaVm = mapeador.Map<ListarProdutoViewModel>(listaSelecionada);

        ViewBag.Produtos = CarregarProdutos();

        return View();
    }
    public List<ListarProdutosViewModel> CarregarProdutos()
    {
        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        List<ListarProdutosViewModel> listarVm = mapeador.Map<List<ListarProdutosViewModel>>(produtos);

        return listarVm;
    }
}
