using AutoMapper;

namespace ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;

public class ItensProdutoProfile : Profile
{
    public ItensProdutoProfile()
    {
        CreateMap<ItensProduto, ListarItensProdutos>()
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

        CreateMap<Produto, ListarItensProdutos>()
    .ForCtorParam(
        "Id",
        opt => opt.MapFrom(src => src.Id)
    )
    .ForCtorParam(
        "ProdutoNome",
        opt => opt.MapFrom(src => src.Nome)
    )
    .ForCtorParam(
        "Quantidade",
        opt => opt.MapFrom(src => 0)
    )
    .ForCtorParam(
        "Categoria",
        opt => opt.MapFrom(src => src.Categoria.Nome)
    )
    .ForCtorParam(
        "Preco",
        opt => opt.MapFrom(src => src.PrecoAproximado)
    );
    }

}
