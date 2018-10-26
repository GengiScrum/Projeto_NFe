using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Issuers.Queries
{
    [ExcludeFromCodeCoverage]
    public class IssuerQuery
    {
        public virtual int Quantity { get; set; }

        public IssuerQuery() { }

        public IssuerQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
