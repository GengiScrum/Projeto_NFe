using AutoMapper;
using Projeto_NFe.Application.Features.ProductTaxes.Commands;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductTaxes
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductTaxRegisterCommand, ProductTax>()
                .ForMember(pt => pt.IcmsAliquot, m => m.MapFrom(ptm => ptm.IcmsAliquot))
                .ForMember(pt => pt.IpiAliquot, m => m.MapFrom(ptm => ptm.IpiAliquot));
        }
    }
}
