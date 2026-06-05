using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Infra;

public class RepositorioListaDeCompraEmArquivo : RepositorioBaseEmArquivo<ListaDeCompra>, IRepositorioListaDeCompra
{
    public RepositorioListaDeCompraEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<ListaDeCompra> CarregarRegistros()
    {
        return contexto.ListasDeCompra;
    }
}
