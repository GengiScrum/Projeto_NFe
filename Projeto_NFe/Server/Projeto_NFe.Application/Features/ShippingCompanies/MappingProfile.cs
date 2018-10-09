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
            CreateMap<ShippingCompanyRegisterCommand, ShippingCompany>();
            CreateMap<ShippingCompany, ShippingCompanyViewModel>()
                .ForMember(tq => tq.PersonType, mt => mt.MapFrom(t => t.PersonType.GetHashCode()))
                .ForMember(tq => tq.Neighborhood, mt => mt.MapFrom(t => t.Address.Neighborhood))
                .ForMember(tq => tq.State, mt => mt.MapFrom(t => t.Address.State))
                .ForMember(tq => tq.StreetName, mt => mt.MapFrom(t => t.Address.StreetName))
                .ForMember(tq => tq.City, mt => mt.MapFrom(t => t.Address.City))
                .ForMember(tq => tq.Number, mt => mt.MapFrom(t => t.Address.Number))
                .ForMember(tq => tq.Country, mt => mt.MapFrom(t => t.Address.Country));
            CreateMap<ShippingCompanyUpdateCommand, ShippingCompany>();
        }
    }
}
