using AutoMapper;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ListarProdutosViewModel>();
    }
}
