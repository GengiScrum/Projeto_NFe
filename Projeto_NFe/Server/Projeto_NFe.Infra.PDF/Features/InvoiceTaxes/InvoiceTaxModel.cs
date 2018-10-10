using Projeto_NFe.Domain.Features.InvoiceTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.InvoiceTaxes
{
    public class InvoiceTaxModel
    {
        public int Id { get; set; }
        public double InvoiceIpiValue { get; set; }
        public double InvoiceIcmsValue { get; set; }
        public double ShippingValue { get; set; }
        public double ProductAmount { get; set; }
        public double InvoiceAmount { get; set; }

        public void Create(InvoiceTax tax)
        {
            ShippingValue = tax.ShippingValue;
            InvoiceIcmsValue = tax.InvoiceIcmsValue;
            InvoiceIpiValue = tax.InvoiceIpiValue;
            InvoiceAmount = tax.InvoiceAmount;
            ProductAmount = tax.ProductAmount;
        }
    }
}
