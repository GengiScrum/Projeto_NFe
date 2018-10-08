using Projeto_NFe.Application.Features.ProductsSold;
using Projeto_NFe.Infra.PDF.Features.ProductTaxes;
using Projeto_NFe.Infra.PDF.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.ProductsSold
{
    public class ProductSoldModel : ProductModel
    {
        public int IdProductSold { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public ProductTaxModel Tax { get; set; }

        public List<ProductSoldModel> CreateLista(IEnumerable<ProductSold> products)
        {
            List<ProductSoldModel> productsModel = new List<ProductSoldModel>();
            foreach (ProductSold product in products)
            {
                Code = product.Code;
                Description = product.Description;
                IdProductSold = product.IdProductSold;
                Tax = new ProductTaxModel();
                Tax.Create(product.Tax);
                Quantity = product.Quantity;
                Amount = product.Amount;
                UnitaryValue = product.UnitaryValue;
                productsModel.Add(this);
            }
            return productsModel;
        }
    }
}
