using AutoMapper;
using Projeto_NFe.Application.Features.Addresses.Commands;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addresses
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressCommand, Address>()
                .ForMember(e => e.Neighborhood, m => m.MapFrom(em => em.Neighborhood))
                .ForMember(e => e.State, m => m.MapFrom(em => em.State))
                .ForMember(e => e.StreetName, m => m.MapFrom(em => em.StreetName))
                .ForMember(e => e.City, m => m.MapFrom(em => em.City))
                .ForMember(e => e.Number, m => m.MapFrom(em => em.Number))
                .ForMember(e => e.Country, m => m.MapFrom(em => em.Country));
        }
    }
}
