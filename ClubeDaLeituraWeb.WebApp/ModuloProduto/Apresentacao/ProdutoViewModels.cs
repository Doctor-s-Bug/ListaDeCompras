namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao;

public record ListarProdutosViewModel(
    string Id,
    string Nome,
    string UnidadeMedida,
    decimal PrecoAproximado,
    string Categoria
);

public record CadastrarProdutosViewModel(
    string Nome,
    string UnidadeMedida,
    decimal PrecoAproximado,
    string Categoria
);

public record ExcluirProdutosViewModel(
    string Id,
    string Nome,
    string UnidadeMedida,
    decimal PrecoAproximado,
    string Categoria
);

public record EditarProdutosViewModel(
    string Id,
    string Nome,
    string UnidadeMedida,
    decimal PrecoAproximado,
    string Categoria
);