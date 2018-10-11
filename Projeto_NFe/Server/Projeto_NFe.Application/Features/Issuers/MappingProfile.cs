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
            CreateMap<IssuerRegisterCommand, Issuer>();
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
