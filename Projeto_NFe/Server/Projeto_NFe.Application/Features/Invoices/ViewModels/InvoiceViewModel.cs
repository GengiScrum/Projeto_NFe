using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.ProductsSold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public string IssuerBusinessName { get; set; }
        public string ShippingCompanyBusinessName { get; set; }
        public string AddresseBusinessName { get; set; }
        public List<ProductSold> ProductSolds { get; set; }
        public InvoiceTax InvoiceTax { get; set; }
        public string OperationNature { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
