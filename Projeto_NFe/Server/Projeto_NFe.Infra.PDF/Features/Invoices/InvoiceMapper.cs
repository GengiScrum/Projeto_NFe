using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ProductsSold;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.PDF.Features.Addressees;
using Projeto_NFe.Infra.PDF.Features.Issuers;
using Projeto_NFe.Infra.PDF.Features.Addresses;
using Projeto_NFe.Infra.PDF.Features.InvoiceTaxes;
using Projeto_NFe.Infra.PDF.Features.ProductTaxes;
using Projeto_NFe.Infra.PDF.Features.ProductsSold;
using Projeto_NFe.Infra.PDF.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.Invoices
{
    public class InvoiceMapper
    {
        IssuerMapper _issuerMap;
        AddresseeMapper _addresseeMap;
        ShippingCompanyMapper _shippingCompanyMap;
        ProductSoldMapper _productSoldMap;
        InvoiceTaxMapper _taxInvoiceMap;

        public void Map(PdfStamper pdfStamp, InvoiceModel invoiceModel)
        {
            _issuerMap = new IssuerMapper();
            _addresseeMap = new AddresseeMapper();
            _shippingCompanyMap = new ShippingCompanyMapper();
            _productSoldMap = new ProductSoldMapper();
            _taxInvoiceMap = new InvoiceTaxMapper();

            var fields = pdfStamp.AcroFields;
            fields.SetField("IDE_REFNFECB", invoiceModel.AcessKey);
            fields.SetField("IDE_REFNFEMASK", invoiceModel.AcessKey);
            fields.SetField("IDE_DEMI", invoiceModel.IssueDate.ToShortDateString());
            fields.SetField("IDE_DSAIENT", invoiceModel.EntryDate.ToShortDateString());
            fields.SetField("IDE_NNF", invoiceModel.Id.ToString());
            fields.SetField("IDE_NATOP", invoiceModel.OperationNature);
            fields.SetField("DESC_CAMPO1", "Query de autenticidade no portal nacional da NF-e www.nfe.fazenda.gov.br/portal ou no site da Sefaz Autorizada");
            _issuerMap.Map(fields, invoiceModel.Issuer);
            _addresseeMap.Map(fields, invoiceModel.Addressee);
            _shippingCompanyMap.Map(fields, invoiceModel.ShippingCompany, invoiceModel.Addressee);
            _taxInvoiceMap.Map(fields, invoiceModel.Tax);
            _productSoldMap.Map(fields, invoiceModel.Products);
        }
    }
}
