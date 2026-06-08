using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public record ListarListasViewModel(
    string Id,
    string Nome,
    StatusLista StatusLista,
    List<ListarProdutoViewModel> Produtos,
    decimal ValorTotal,
    string DataCriacao
);
public record CadastrarListaViewModel(
    string Nome
);
public record ExcluirListaViewModel(
    string Id,
    string Nome,
    string DataCriacao,
    StatusLista StatusLista
);
public record EditarListaViewModel(
    string Id,
    string Nome,
    string DataCriacao,
    StatusLista StatusLista
);