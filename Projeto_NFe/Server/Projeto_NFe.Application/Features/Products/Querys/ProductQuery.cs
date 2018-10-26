using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products.Queries
{
    [ExcludeFromCodeCoverage]
    public class ProductQuery
    {
        public virtual int Quantity {get; set;}

        public ProductQuery() { }

        public ProductQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
