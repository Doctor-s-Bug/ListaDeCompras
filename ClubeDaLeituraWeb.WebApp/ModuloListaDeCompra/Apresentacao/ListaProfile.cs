using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloItensProduto.Dominio;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public class ListaProfile : Profile
{
    public ListaProfile()
    {
        CreateMap<ListaDeCompra, ListarListasViewModel>()
            .ForCtorParam(
                "Id",
                opt => opt.MapFrom(src => src.Id)
            )
            .ForCtorParam(
                "Nome",
                opt => opt.MapFrom(src => src.Nome)
            )
            .ForCtorParam(
                "StatusLista",
                opt => opt.MapFrom(src => src.StatusLista)
            )
            .ForCtorParam(
                "Produtos",
                opt => opt.MapFrom(src => src.ListaProdutos)
            )
            .ForCtorParam(
                "ValorTotal",
                opt => opt.MapFrom(src => src.ValorTotal)
            )
            .ForCtorParam(
                "DataCriacao",
                opt => opt.MapFrom(src => src.DataCriacao.ToString("dd/MM/yyyy"))
            );
        CreateMap<ListaDeCompra, ExcluirListaViewModel>().ForCtorParam(
        nameof(ListaDeCompra.DataCriacao),
        opt => opt.MapFrom(src => src.DataCriacao.ToString("dd/MM/yyyy"))
        );
        CreateMap<ListaDeCompra, EditarListaViewModel>().ForCtorParam(
        nameof(ListaDeCompra.DataCriacao),
        opt => opt.MapFrom(src => src.DataCriacao.ToString("dd/MM/yyyy"))
        );
        CreateMap<EditarListaViewModel, ListaDeCompra>();
        CreateMap<Produto, ListarProdutoViewModel>();

    }
}
