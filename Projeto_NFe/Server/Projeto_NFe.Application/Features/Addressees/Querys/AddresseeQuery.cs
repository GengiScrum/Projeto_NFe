using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addressees.Queries
{
    [ExcludeFromCodeCoverage]
    public class AddresseeQuery
    {
        public virtual int Quantity { get; set; }

        public AddresseeQuery(int quantity)
        {
            Quantity = quantity;
        }
    }
}
