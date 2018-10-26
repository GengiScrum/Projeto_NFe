using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies.Queries
{
    [ExcludeFromCodeCoverage]
    public class ShippingCompanyQuery
    {
        public virtual int Quantity { get; set; }

        public ShippingCompanyQuery() { }

        public ShippingCompanyQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
