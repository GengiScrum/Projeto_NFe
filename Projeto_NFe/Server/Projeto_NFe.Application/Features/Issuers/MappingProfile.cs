using AutoMapper;
using Projeto_NFe.Application.Features.Issuers.Commands;
using Projeto_NFe.Application.Features.Issuers.ViewModel;
using Projeto_NFe.Domain.Features.Issuers;

namespace Projeto_NFe.Application.Features.Issuers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IssuerRegisterCommand, Issuer>()
                .ForPath(e => e.Address.Neighborhood, m => m.MapFrom(em => em.Neighborhood))
                .ForPath(e => e.Address.State, m => m.MapFrom(em => em.State))
                .ForPath(e => e.Address.StreetName, m => m.MapFrom(em => em.StreetName))
                .ForPath(e => e.Address.City, m => m.MapFrom(em => em.City))
                .ForPath(e => e.Address.Number, m => m.MapFrom(em => em.Number))
                .ForPath(e => e.Address.Country, m => m.MapFrom(em => em.Country));
            CreateMap<Issuer, IssuerViewModel>()
                .ForMember(e => e.Neighborhood, m => m.MapFrom(em => em.Address.Neighborhood))
                .ForMember(e => e.State, m => m.MapFrom(em => em.Address.State))
                .ForMember(e => e.StreetName, m => m.MapFrom(em => em.Address.StreetName))
                .ForMember(e => e.City, m => m.MapFrom(em => em.Address.City))
                .ForMember(e => e.Number, m => m.MapFrom(em => em.Address.Number))
                .ForMember(e => e.Country, m => m.MapFrom(em => em.Address.Country));
            CreateMap<IssuerUpdateCommand, Issuer>();
        }
    }
}
