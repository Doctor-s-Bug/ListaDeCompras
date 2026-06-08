namespace ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

public record ListarProdutoViewModel(
    string Id,
    string ProdutoNome,
    int Quantidade,
    string Categoria,
    decimal Preco
);
