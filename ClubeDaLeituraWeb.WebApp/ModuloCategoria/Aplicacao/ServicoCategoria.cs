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
        if (ExisteCategoriaComNome(dto.Nome))
            return Falha("Nome", "Já existe uma Categoria com esse Nome");

        Categoria novaCategoria = new(
            dto.Nome,
            dto.Cor
        );

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }
    public Result Editar(EditarCategoriaDto dto)
    {
        if (ExisteCategoriaComNome(dto.Nome, dto.Id))
            return Falha("Nome", "Já existe uma Categoria com esse Nome");

        Categoria categoriaAtualizada = new(
            dto.Nome,
            dto.Cor
        );
        bool conseguiuEditar = repositorioCategoria.Editar(dto.Id, categoriaAtualizada);

        if (!conseguiuEditar)
            return Result.Fail("Caixa não encontrada!");

        return Result.Ok();
    }
    public Result Excluir(string Id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(Id);

        if (categoria == null)
            return Result.Fail("Categoria não encontrada");

        repositorioCategoria.Excluir(Id);

        return Result.Ok();
    }
    private bool ExisteCategoriaComNome(string nome, string? idIgnorado = null)
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        foreach (Categoria item in categorias)
        {
            if (item.Id != idIgnorado && item.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
