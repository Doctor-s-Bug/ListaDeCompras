namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaViewModels
{
    public record ListarCategoriaViewModel(
        string Id,
        string Nome,
        string Cor
    );
    public record CadastrarCategoriaViewModel(
        string Nome,
        string Cor
    );
    public record ExcluirCategoriaViewModel(
        string Id,
        string Nome,
        string Cor
    );
    public record EditarCategoriaViewModel(
        string Id,
        string Nome,
        string Cor
    );
}
