using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }
    public void Listar(List<ListarCategoriaDto> dto)
    {

    }
}
