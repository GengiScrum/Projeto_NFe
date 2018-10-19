using AutoMapper;
using Projeto_NFe.Application.Features.ProductSolds.Commands;
using Projeto_NFe.Domain.Features.ProductsSold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductSolds
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductSoldRegisterCommand, ProductSold>();
            CreateMap<ProductSoldUpdateCommand, ProductSold>();
        }
    }
}
