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
                .ForMember(i => i.IssuerBusinessName, m => m.MapFrom(v => v.Issuer.BusinessName))
                .ForMember(i => i.AddresseBusinessName, m => m.MapFrom(v => v.Addressee.BusinessName))
                .ForMember(i => i.ShippingCompanyBusinessName, m => m.MapFrom(v => v.ShippingCompany.BusinessName));
            CreateMap<InvoiceUpdateCommand, Invoice>();
        }
    }
}
