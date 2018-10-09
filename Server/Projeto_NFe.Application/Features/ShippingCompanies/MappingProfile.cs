using AutoMapper;
using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.ViewModel;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShippingCompanyRegisterCommand, ShippingCompany>()
                .ForPath(sc => sc.Address.Neighborhood, m => m.MapFrom(scm => scm.Neighborhood))
                .ForPath(sc => sc.Address.State, m => m.MapFrom(scm => scm.State))
                .ForPath(sc => sc.Address.StreetName, m => m.MapFrom(scm => scm.StreetName))
                .ForPath(sc => sc.Address.City, m => m.MapFrom(scm => scm.City))
                .ForPath(sc => sc.Address.Number, m => m.MapFrom(scm => scm.Number))
                .ForPath(sc => sc.Address.Country, m => m.MapFrom(scm => scm.Country));
            CreateMap<ShippingCompany, ShippingCompanyViewModel>()
                .ForMember(sc => sc.PersonType, m => m.MapFrom(scm => scm.PersonType.GetHashCode()))
                .ForMember(sc => sc.Neighborhood, m => m.MapFrom(scm => scm.Address.Neighborhood))
                .ForMember(sc => sc.State, m => m.MapFrom(scm => scm.Address.State))
                .ForMember(sc => sc.StreetName, m => m.MapFrom(scm => scm.Address.StreetName))
                .ForMember(sc => sc.City, m => m.MapFrom(scm => scm.Address.City))
                .ForMember(sc => sc.Number, m => m.MapFrom(scm => scm.Address.Number))
                .ForMember(sc => sc.Country, m => m.MapFrom(scm => scm.Address.Country));
            CreateMap<ShippingCompanyUpdateCommand, ShippingCompany>();
        }
    }
}
