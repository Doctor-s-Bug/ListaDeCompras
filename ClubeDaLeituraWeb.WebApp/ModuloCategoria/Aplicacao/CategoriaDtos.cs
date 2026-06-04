using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;

public record ListarCategoriaDto(
        string Id,
        string Nome,
        CorCategoria Cor
    );
public record CadastrarCategoriaDto(
        string Nome,
        CorCategoria Cor
    );
public record EditarCategoriaDto(
    string Id,
    string Nome,
    CorCategoria Cor
);
public record ExcluirCategoriaDto(
        string Id,
        string Nome,
        CorCategoria Cor
    );