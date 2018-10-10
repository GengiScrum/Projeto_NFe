using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.ProductsSold;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public class Invoice
    {
        public int Id { get; set; }
        public Issuer Issuer { get; set; }
        public ShippingCompany ShippingCompany { get; set; }
        public Addressee Addressee { get; set; }
        public IEnumerable<ProductSold> Products { get; set; }
        public InvoiceTax Tax { get; set; }
        public string OperationNature { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string AcessKey { get; set; }

        public virtual void Validate()
        {
            Addressee.Validate();
            foreach (ProductSold product in Products)
                product.Validate();
        }

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
            Tax.Calculate(Products);
        }
    }
}
