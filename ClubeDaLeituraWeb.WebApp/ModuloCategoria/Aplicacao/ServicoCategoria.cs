using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using FluentResults;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;

public class ServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }
    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        foreach (Categoria item in categorias)
        {
            if (item.Nome.Equals(dto.Nome, StringComparison.OrdinalIgnoreCase))
            {
                Error erroValidacao = new Error("Já Existe uma Categoria com esse Nome!")
                .WithMetadata("Campo", nameof(item.Nome));

                return Result.Fail(erroValidacao);
            }
        }

        Categoria novaCategoria = new(
            dto.Nome,
            dto.Cor
        );

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }
}
