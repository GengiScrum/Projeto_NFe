using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Invoices
{
    public interface IInvoiceRepository
    {
        Invoice Add(Invoice invoice);
        Invoice Update(Invoice invoice);
        void Remove(int id);
        Invoice GetById(int id);
        IEnumerable<Invoice> GetAll();
    }
}
