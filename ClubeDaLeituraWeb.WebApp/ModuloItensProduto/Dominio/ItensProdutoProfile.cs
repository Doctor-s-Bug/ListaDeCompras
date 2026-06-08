using AutoMapper;

namespace ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

public class ItensProdutoProfile : Profile
{
    public ItensProdutoProfile()
    {
        CreateMap<ItensProduto, ListarProdutoViewModel>()
    .ForCtorParam("Id",
        opt => opt.MapFrom(src => src.Id))
    .ForCtorParam("ProdutoNome",
        opt => opt.MapFrom(src => src.Produto.Nome))
    .ForCtorParam("Quantidade",
        opt => opt.MapFrom(src => src.QuantidadeProduto))
    .ForCtorParam("Categoria",
        opt => opt.MapFrom(src => src.Produto.Categoria.Nome))
    .ForCtorParam("Preco",
        opt => opt.MapFrom(src => src.Produto.PrecoAproximado));//aqui peguei do chatzao kkkk
    }
}
