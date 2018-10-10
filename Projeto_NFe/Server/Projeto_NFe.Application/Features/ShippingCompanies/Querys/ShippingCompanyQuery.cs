using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies.Querys
{
    public class ShippingCompanyQuery
    {
        public virtual int Quantity { get; set; }

        public ShippingCompanyQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
