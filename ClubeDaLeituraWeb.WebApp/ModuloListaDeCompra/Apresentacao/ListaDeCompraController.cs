using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public class ListaDeCompraController : Controller
{
    private readonly IRepositorioListaDeCompra repositorioListaDeCompra;
    private readonly ServicoLista servicoLista;
    private readonly IMapper mapeador;

    public ListaDeCompraController(ServicoLista servicoLista, IRepositorioListaDeCompra repositorioListaDeCompra, IMapper mapeador)
    {
        this.servicoLista = servicoLista;
        this.repositorioListaDeCompra = repositorioListaDeCompra;
        this.mapeador = mapeador;
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
}
