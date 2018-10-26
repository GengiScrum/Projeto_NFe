using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.SoldProducts;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class Invoice
    {
        public virtual int Id { get; set; }
        public int? IssuerId { get; set; }
        public Issuer Issuer { get; set; }
        public int? ShippingCompanyId { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public int? AddresseeId { get; set; }
        public Addressee Addressee { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
        public int?  InvoiceTaxId { get; set; }
        public InvoiceTax InvoiceTax { get; set; }
        public string OperationNature { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string AcessKey { get; set; }

        public void ValidateAcessKey()
        {
            //if (String.IsNullOrEmpty(AcessKey)) throw new IssuedInvoiceChaveDeAcessoInvalidExcecao();
        } 

        public void Issue()
        {
            IssueDate = DateTime.Now;
            AcessKey = GenerateAcessKey();
            ValidateAcessKey();
            CalculateTax();
        }

        private string GenerateAcessKey()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            return num.ToString("X");
        }

        public void CalculateTax()
        {
            InvoiceTax.Calculate(SoldProducts);
        }
    }
}
