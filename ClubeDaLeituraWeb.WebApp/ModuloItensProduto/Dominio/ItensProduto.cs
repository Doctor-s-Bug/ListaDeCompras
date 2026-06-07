using System.Security.Cryptography;

namespace ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

public class ItensProduto
{

    public string Id { get; set; }
    public Produto Produto { get; set; }
    public int QuantidadeProduto { get; set; }
    public ItensProduto()
    {

    }
    public ItensProduto(Produto produto, int quantidadeProduto)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);

        Produto = produto;
        QuantidadeProduto = quantidadeProduto;
    }
}
