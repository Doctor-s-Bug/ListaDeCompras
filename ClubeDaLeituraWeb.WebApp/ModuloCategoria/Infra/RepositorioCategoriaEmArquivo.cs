using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Arquivos;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Infra;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(ContextoJson contexto) : base(contexto) { }
    protected override List<Categoria> CarregarRegistros()
    {
        return contexto.Categorias;
    }
}
