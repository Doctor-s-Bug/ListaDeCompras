using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm.Config;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using Microsoft.EntityFrameworkCore;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;

//Esse parametro é para que o DbContext pegue as configuracoes la da injecao de dependencia
public class ListaDeComprasDbContext(DbContextOptions<ListaDeComprasDbContext> options) : DbContext(options)
{
    //Aqui instacia a "Tabela dos objetos"
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<ListaDeCompra> ListasDeCompras => Set<ListaDeCompra>();
    public DbSet<ItensProduto> ItensProdutos => Set<ItensProduto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Aplica a configuracao no builder do DbContext

        modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfigurations());
        modelBuilder.ApplyConfiguration(new ListaDeComprasConfigurations());
    }
}
