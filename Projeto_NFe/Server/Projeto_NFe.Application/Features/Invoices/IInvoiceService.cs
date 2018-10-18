using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices
{
    public interface IInvoiceService
    {
        int Add(InvoiceRegisterCommand command);
        bool Update(InvoiceUpdateCommand command);
        bool Remove(InvoiceRemoveCommand command);
        Invoice GetById(int id);
        IQueryable<Invoice> GetAll();
        IQueryable<Invoice> GetAll(InvoiceQuery query);
    }
}