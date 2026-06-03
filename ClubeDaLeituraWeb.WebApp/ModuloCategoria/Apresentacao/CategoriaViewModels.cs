namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaViewModels
{
    public record ListarCategoriaViewModels(
        string Id,
        string Nome,
        string CategoriaCor
    );
}
