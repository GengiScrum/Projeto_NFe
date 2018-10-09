using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Features.IssuedInvoices
{
    public interface IIssuedInvoiceXMLRepository
    {
        void Export(Invoice invoice, string file);
    }
}
