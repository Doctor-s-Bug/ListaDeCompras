using System.ComponentModel.DataAnnotations;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaViewModels
{
    public record ListarCategoriaViewModel(
        string Id,
        string Nome,
        string Cor
    );
    public record CadastrarCategoriaViewModel(
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo \"Nome\" deve conter entre 3 à 20 caracteres.", MinimumLength = 3)]
        string Nome,
        [Required(ErrorMessage = "O campo \"Cor\" é obrigatório!")]
        string Cor
    );
    public record ExcluirCategoriaViewModel(
        string Id,
        string Nome,
        string Cor
    );
    public record EditarCategoriaViewModel(
        string Id,
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo \"Nome\" deve conter entre 3 à 20 caracteres.", MinimumLength = 3)]
        string Nome,
        [Required(ErrorMessage = "O campo \"Cor\" é obrigatório!")]
        string Cor
    );
}
