namespace ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

public record ListarItensProdutos(
    string Id,
    string ProdutoNome,
    int Quantidade,
    string Categoria,
    decimal Preco
);
