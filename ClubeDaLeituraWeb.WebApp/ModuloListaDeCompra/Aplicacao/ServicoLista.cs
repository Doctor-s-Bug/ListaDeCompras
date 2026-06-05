using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Aplicacao;

public class ServicoLista
{
    private readonly IRepositorioListaDeCompra repositorioListaDeCompra;
    private readonly IMapper mapeador;

    public ServicoLista(IRepositorioListaDeCompra repositorioListaDeCompra, IMapper mapeador)
    {
        this.repositorioListaDeCompra = repositorioListaDeCompra;
        this.mapeador = mapeador;
    }

    public void SelecionarTodos()
    {
        List<ListaDeCompra> listaDeCompras = repositorioListaDeCompra.SelecionarTodos();

        
    }
}
