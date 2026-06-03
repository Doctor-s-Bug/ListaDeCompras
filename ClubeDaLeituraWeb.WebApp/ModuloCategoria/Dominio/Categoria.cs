
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;


public class Categoria : EntidadeBase<Categoria>
{
    public string Nome { get; set; }
    public string Cor { get; set; }

    public Categoria()
    {
    }

    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 2 || Nome.Length > 50)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 50 caracteres.");

        else if (Cor.Length < 3 || Cor.Length > 20)
            erros.Add("O campo \"Cor\" deve conter entre 3 a 20 caracteres.");

        return erros;
    }

    public override void Atualizar(Categoria categoriaAtualizada)
    {
        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}
