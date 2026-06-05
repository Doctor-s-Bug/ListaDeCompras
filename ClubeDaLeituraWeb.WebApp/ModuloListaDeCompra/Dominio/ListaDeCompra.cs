using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

public class ListaDeCompra : EntidadeBase<ListaDeCompra>
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Today;
    public StatusLista StatusLista { get; set; } = StatusLista.Aberta;
    
    public ListaDeCompra()
    {

    }
    public ListaDeCompra(string nome)
    {
        Nome = nome;
    }
    
    public override List<string> Validar()
    {
        List<string> erros = [];

        if (String.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome não pode ser Vazio!;");
        else if (Nome.Length < 3 || Nome.Length > 20)
            erros.Add("Nome deve conter entre 4 a 20 caracteres!;");

        return erros;
    }

    public override void Atualizar(ListaDeCompra entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        StatusLista = entidadeAtualizada.StatusLista;
    }
}
