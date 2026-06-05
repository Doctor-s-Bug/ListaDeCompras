using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public record ListarListasViewModel(
    string Id,
    string Nome,
    string DataCriacao,
    StatusLista StatusLista
);
public record CadastrarListaViewModel(
    string Nome
);