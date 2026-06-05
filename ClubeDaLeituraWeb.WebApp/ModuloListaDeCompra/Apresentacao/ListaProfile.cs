using AutoMapper;
using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;

namespace ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Apresentacao;

public class ListaProfile : Profile
{
    public ListaProfile()
    {
        CreateMap<ListarListasViewModel, ListaDeCompra>();
    }
}
