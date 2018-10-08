using Projeto_NFe.Domain.Features.ProductTaxes;
using Projeto_NFe.Application.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ProductsSold
{
    public class ProductSold : Product
    {
        public int IdProductSold { get; set; }
        public int Quantity { get; set; }
        public double Amount => GetAmount();
        public ProductTax Tax { get; set; }

        public override void Validate()
        {
            //if (Quantity < 1)
            //    throw new ProductSoldQuantityExcecao();
        }

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
