using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.SoldProducts.Queries
{
    [ExcludeFromCodeCoverage]
    public class SoldProductQuery
    {
        public virtual int Quantity { get; set; }

        public virtual int InvoiceId { get; set; }

        public SoldProductQuery() { }

        public SoldProductQuery(int quantity, int invoiceId)
        {
            Quantity = quantity;
            InvoiceId = invoiceId;
        }
    }
}
