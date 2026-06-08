using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

public class ListaDeCompra : EntidadeBase<ListaDeCompra>
{
    public string Nome { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Today;
    public StatusLista StatusLista { get; set; } = StatusLista.Aberta;
    public List<ItensProduto> ListaProdutos { get; set; } = new();
    public decimal ValorTotal
    {
        get
        {
            decimal total = 0;

            foreach (ItensProduto item in ListaProdutos)
            {
                decimal precoProduto = item.Produto.PrecoAproximado;
                decimal Quantidade = item.QuantidadeProduto;

                total += precoProduto * Quantidade;
            }
            return total;
        }
    }

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
        ListaProdutos = entidadeAtualizada.ListaProdutos;
    }
    public void AddItem(ItensProduto itensProduto)
    {
        ListaProdutos.Add(itensProduto);
    }
    public void RemoverItem(ItensProduto itensProduto)
    {
        ListaProdutos.Remove(itensProduto);
    }
}
