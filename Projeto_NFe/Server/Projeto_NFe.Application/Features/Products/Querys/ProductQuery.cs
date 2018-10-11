using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Queries
{
    public class ProductQuery
    {
        public virtual int Quantity {get; set;}

        public ProductQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
