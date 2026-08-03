using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Compartilhado;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Infra;

public class RepositorioListaDeCompraEmOrm(ListaDeComprasDbContext dbContext)
    : RepositorioBaseEmOrm<ListaDeCompra>(dbContext), IRepositorioListaDeCompra
{
    public override List<ListaDeCompra> SelecionarTodos()
    {
        return registros.Include(l => l.Produtos).ToList();
    }
    public override ListaDeCompra? SelecionarPorId(string idSelecionado)
    {
        return registros.Include(l => l.Produtos).SingleOrDefault(l => idSelecionado == l.Id);
    }
}
