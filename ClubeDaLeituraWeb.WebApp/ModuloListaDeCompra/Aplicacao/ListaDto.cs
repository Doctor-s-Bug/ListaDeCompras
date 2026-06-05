using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Aplicacao;

public record ListarListaCompraDto(
    string Id,
    string Nome,
    string DataCriacao,
    StatusLista StatusLista
);

