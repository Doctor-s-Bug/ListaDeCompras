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
}
