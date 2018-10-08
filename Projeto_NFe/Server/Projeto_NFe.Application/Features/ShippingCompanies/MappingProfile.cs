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
                .ForPath(scm => scm.Address.City, m => m.MapFrom(sc => sc.City))
                .ForPath(scm => scm.Address.Country, m => m.MapFrom(sc => sc.Country))
                .ForPath(scm => scm.Address.Neighborhood, m => m.MapFrom(sc => sc.Neighborhood))
                .ForPath(scm => scm.Address.Number, m => m.MapFrom(sc => sc.Number))
                .ForPath(scm => scm.Address.State, m => m.MapFrom(sc => sc.State))
                .ForPath(scm => scm.Address.StreetName, m => m.MapFrom(sc => sc.StreetName));
            CreateMap<ShippingCompany, ShippingCompanyViewModel>()
                .ForMember(sc => sc.PersonType, mt => mt.MapFrom(t => t.PersonType.GetHashCode()))
                .ForMember(sc => sc.Neighborhood, mt => mt.MapFrom(t => t.Address.Neighborhood))
                .ForMember(sc => sc.State, mt => mt.MapFrom(t => t.Address.State))
                .ForMember(sc => sc.StreetName, mt => mt.MapFrom(t => t.Address.StreetName))
                .ForMember(sc => sc.City, mt => mt.MapFrom(t => t.Address.City))
                .ForMember(sc => sc.Number, mt => mt.MapFrom(t => t.Address.Number))
                .ForMember(sc => sc.Country, mt => mt.MapFrom(t => t.Address.Country));
            CreateMap<ShippingCompanyUpdateCommand, ShippingCompany>();
        }
    }
}
