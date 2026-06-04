using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;

public class Produto : EntidadeBase<Produto>
{
    public string Nome { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal PrecoAproximado { get; private set; }
    public Categoria Categoria { get; private set; }

    public Produto(
        string nome,
        string unidadeMedida,
        decimal precoAproximado,
        Categoria categoria
    )
    {
        Nome = nome;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
        Categoria = categoria;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve ser preenchido.");

        if (PrecoAproximado == 0)
            erros.Add("O campo \"Preço Aproximado\" deve ser preenchido.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido.");

        return erros;
    }

    public override void Atualizar(Produto entidadeAtualizada)
    {

        Nome = entidadeAtualizada.Nome;
        UnidadeMedida = entidadeAtualizada.UnidadeMedida;
        PrecoAproximado = entidadeAtualizada.PrecoAproximado;
        Categoria = entidadeAtualizada.Categoria;
    }
}