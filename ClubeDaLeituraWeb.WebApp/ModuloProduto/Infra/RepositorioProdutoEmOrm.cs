using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Compartilhado;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using ClubeDaLeituraWeb.WebApp.ModuloProduto.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Infra;

public class RepositorioProdutoEmOrm(ListaDeComprasDbContext dbContext)
: RepositorioBaseEmOrm<Produto>(dbContext), IRepositorioProduto
{
    public override List<Produto> SelecionarTodos()
    {
        return registros.Include(p => p.Categoria).ToList();
    }
    public override Produto? SelecionarPorId(string idSelecionado)
    {
        return registros.Include(p => p.Categoria).SingleOrDefault(p => p.Id == idSelecionado);
    }
}
