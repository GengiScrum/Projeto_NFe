using Projeto_NFe.Domain.Features.SoldProducts;
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
        bool RemoveSoldProducts(int invoiceId, int[] soldProductsIds);
        Invoice GetById(int id);
        IQueryable<Invoice> GetAll();
        IQueryable<Invoice> GetAll(int quantity);
        IQueryable<SoldProduct> GetAllSoldProducts(int invoiceId);
        IQueryable<SoldProduct> GetAllSoldProducts(int quantity, int invoiceId);
    }
}
