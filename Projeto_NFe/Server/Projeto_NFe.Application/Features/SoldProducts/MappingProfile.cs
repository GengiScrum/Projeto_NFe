using AutoMapper;
using Projeto_NFe.Application.Features.SoldProducts.Commands;
using Projeto_NFe.Application.Features.SoldProducts.ViewModels;
using Projeto_NFe.Domain.Features.SoldProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.SoldProducts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SoldProductRegisterCommand, SoldProduct>();
            CreateMap<SoldProduct, SoldProductViewModel>()
                .ForMember(sp => sp.ProductId, m => m.MapFrom (spm => spm.Product.Id))
                .ForMember(sp => sp.Description, m => m.MapFrom (spm => spm.Product.Description))
                .ForMember(sp => sp.Code, m => m.MapFrom(spm => spm.Product.Code))
                .ForMember(sp => sp.UnitaryValue, m => m.MapFrom(spm => spm.Product.UnitaryValue));
        }
    }
}
