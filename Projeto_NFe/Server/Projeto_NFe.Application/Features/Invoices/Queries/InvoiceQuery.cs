using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices.Queries
{
    [ExcludeFromCodeCoverage]
    public class InvoiceQuery
    {
        public virtual int Quantity { get; set; }

        public InvoiceQuery() { }

        public InvoiceQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
