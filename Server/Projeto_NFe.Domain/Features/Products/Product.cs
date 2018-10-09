using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }

        public virtual void Validate()
        {
            //if (Code.Length < 1 || Code.Length > 40)
            //    throw new ProductCodeInvalidExcecao();
            //if (Description.Length < 1 || Description.Length > 40)
            //    throw new ProductDescriptionInvalidExcecao();
            //if (UnitaryValue < 1)
            //    throw new ProductValueInvalidExcecao();
        }
    }
}
