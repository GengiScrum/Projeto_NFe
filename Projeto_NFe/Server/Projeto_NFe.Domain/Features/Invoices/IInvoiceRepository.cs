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
        bool Update(Invoice invoice);
        bool Remove(int id);
        Invoice GetById(int id);
        IQueryable<Invoice> GetAll();
    }
}
