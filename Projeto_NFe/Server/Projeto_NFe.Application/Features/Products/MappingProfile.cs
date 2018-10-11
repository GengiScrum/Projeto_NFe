using AutoMapper;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.ViewModel;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Application.Features.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRegisterCommand, Product>();
            CreateMap<ProductUpdateCommand, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
