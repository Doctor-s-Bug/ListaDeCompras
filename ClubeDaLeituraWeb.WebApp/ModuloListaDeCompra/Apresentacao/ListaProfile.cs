using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public class ListaProfile : Profile
{
    public ListaProfile()
    {
        CreateMap<ListaDeCompra, ListarListasViewModel>().ForCtorParam(
        nameof(ListaDeCompra.DataCriacao),
        opt => opt.MapFrom(src => src.DataCriacao.ToString("dd/MM/yyyy")) //aq peguei do chat kkkk
    ); ;
    }
}
