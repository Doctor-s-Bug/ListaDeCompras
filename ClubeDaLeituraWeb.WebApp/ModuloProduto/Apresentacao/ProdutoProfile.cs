using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ListarProdutosViewModel>();
    }
}
