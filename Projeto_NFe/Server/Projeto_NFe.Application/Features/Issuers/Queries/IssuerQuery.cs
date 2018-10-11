using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Issuers.Queries
{
    public class IssuerQuery
    {
        public virtual int Quantity { get; set; }

        public IssuerQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
