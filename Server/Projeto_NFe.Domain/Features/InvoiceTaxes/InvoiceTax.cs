using Projeto_NFe.Domain.Features.ProductsSold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.InvoiceTaxes
{
    public class InvoiceTax
    {
        public int Id { get; set; }
        public double InvoiceIpiValue { get; set; }
        public double InvoiceIcmsValue { get; set; }
        public double ShippingValue { get; set; }
        public double ProductAmount { get; set; }
        public double InvoiceAmount { get; set; }

        public virtual void Calculate(IEnumerable<ProductSold> productsSold)
        {
            double ipiValue = 0;
            double icmsValue = 0;
            double amountProduct = 0;

            foreach(ProductSold product in productsSold)
            {
                product.CalculateTax();
                ipiValue += product.Tax.IpiValue;
                icmsValue += product.Tax.IcmsValue;
                amountProduct += product.Amount;
            }

            InvoiceIpiValue = ipiValue;
            InvoiceIcmsValue = icmsValue;
            ProductAmount = amountProduct;
            InvoiceAmount = InvoiceIpiValue + InvoiceIcmsValue + ProductAmount + ShippingValue;
        }
    }
}
