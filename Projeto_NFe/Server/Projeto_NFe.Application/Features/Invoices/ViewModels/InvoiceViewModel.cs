using Projeto_NFe.Application.Features.SoldProducts.ViewModels;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.SoldProducts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string IssuerBusinessName { get; set; }
        public int IssuerId { get; set; }
        public string ShippingCompanyBusinessName { get; set; }
        public int ShippingCompanyId { get; set; }
        public string AddresseeBusinessName { get; set; }
        public int AddresseeId { get; set; }
        public IEnumerable<SoldProductViewModel> SoldProducts { get; set; }
        public InvoiceTax InvoiceTax { get; set; }
        public string OperationNature { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
