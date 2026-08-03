using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Compartilhado;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;

public class RepositorioCategoriaEmOrm(ListaDeComprasDbContext dbContext)
         : RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria
{
    public List<Categoria> Filtrar(Predicate<Categoria> filtro)
    {
        throw new NotImplementedException();
    }
}
