using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.PDF.Features.Addressees;
using Projeto_NFe.Infra.PDF.Features.Issuers;
using Projeto_NFe.Infra.PDF.Features.InvoiceTaxes;
using Projeto_NFe.Infra.PDF.Features.ProductsSold;
using Projeto_NFe.Infra.PDF.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.Invoices
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public IssuerModel Issuer { get; set; }
        public ShippingCompanyModel ShippingCompany { get; set; }
        public AddresseeModel Addressee { get; set; }
        public IEnumerable<ProductSoldModel> Products { get; set; }
        public InvoiceTaxModel Tax { get; set; }
        public string OperationNature { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string AcessKey { get; set; }

        public void Create(Invoice invoice)
        {
            ProductSoldModel productSoldModel = new ProductSoldModel();

            Id = invoice.Id;
            AcessKey = invoice.AcessKey;
            IssueDate = invoice.IssueDate;
            EntryDate = invoice.EntryDate;
            Addressee = new AddresseeModel();
            Addressee.Create(invoice.Addressee);
            Issuer = new IssuerModel();
            Issuer.Create(invoice.Issuer);
            Tax = new InvoiceTaxModel();
            Tax.Create(invoice.Tax);
            OperationNature = invoice.OperationNature;
            Products = new List<ProductSoldModel>();
            Products = productSoldModel.CreateLista(invoice.Products);
            if (invoice.ShippingCompany != null)
            {
                ShippingCompany = new ShippingCompanyModel();
                ShippingCompany.Create(invoice.ShippingCompany);
            }
        }
    }
}
