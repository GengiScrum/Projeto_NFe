using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Domain.Features.ProductsSold
{
    public class ProductSold : Product
    {
        public int IdProductSold { get; set; }
        public int Quantity { get; set; }
        public double Amount => GetAmount();
        public ProductTax Tax { get; set; }
        public int InvoiceId { get; set; }

        private double GetAmount()
        {
            return Quantity * UnitaryValue;
        }

        public void CalculateTax()
        {
            Tax.CalculateIpi(Amount);
            Tax.CalculateIcms(Amount);
        }
    }
}
