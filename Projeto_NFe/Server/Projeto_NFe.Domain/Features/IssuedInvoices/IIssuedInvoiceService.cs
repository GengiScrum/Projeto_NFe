using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.IssuedInvoices
{
    public interface IIssuedInvoiceService
    {
        void ExportToXML(Invoice invoice, string file);
        void ExportToPDF(Invoice invoice, string file);
    }
}
