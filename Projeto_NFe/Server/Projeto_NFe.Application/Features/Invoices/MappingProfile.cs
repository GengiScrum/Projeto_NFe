using AutoMapper;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InvoiceRegisterCommand, Invoice>();
            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(i => i.IssuerBusinessName, m => m.MapFrom(v => v.Issuer != null ? v.Issuer.BusinessName : string.Empty))
                .ForMember(i => i.AddresseeBusinessName, m => m.MapFrom(v => v.Addressee != null ? v.Addressee.BusinessName : string.Empty))
                .ForMember(i => i.ShippingCompanyBusinessName, m => m.MapFrom(v => v.ShippingCompany != null ? v.ShippingCompany.BusinessName : string.Empty));
            CreateMap<InvoiceUpdateCommand, Invoice>();
        }
    }
}
