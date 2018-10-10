using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceService
    {
        Invoice Add(Invoice invoice);
        Invoice Update(Invoice invoice);
        void Remove(Invoice invoice);
        Invoice GetById(Invoice invoice);
        IEnumerable<Invoice> GetAll();
        void Issue(Invoice invoice);
    }
}