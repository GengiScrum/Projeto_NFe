using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Infra.PDF.Features.ProductTaxes;
using Projeto_NFe.Infra.PDF.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.SoldProducts
{
    public class SoldProductModel : ProductModel
    {
        public int IdSoldProduct { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public ProductTaxModel Tax { get; set; }

        public List<SoldProductModel> CreateList(IEnumerable<SoldProduct> products)
        {
            List<SoldProductModel> productsModel = new List<SoldProductModel>();
            foreach (SoldProduct product in products)
            {
                Code = product.Product.Code;
                Description = product.Product.Description;
                Tax = new ProductTaxModel();
                Tax.Create(product.Product.Tax);
                Quantity = product.Quantity;
                Amount = product.Amount;
                UnitaryValue = product.Product.UnitaryValue;
                productsModel.Add(this);
            }
            return productsModel;
        }
    }
}
