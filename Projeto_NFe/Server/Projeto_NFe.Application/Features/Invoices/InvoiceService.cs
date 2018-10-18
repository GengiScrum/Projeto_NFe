using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Invoices.Commands;
using AutoMapper;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        IInvoiceRepository _invoiceRepository;
        

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public int Add(InvoiceRegisterCommand command)
        {
            var invoice = Mapper.Map<InvoiceRegisterCommand, Invoice>(command);
            var newInvoice =  _invoiceRepository.Add(invoice);

            return newInvoice.Id;
        }

        public bool Update(InvoiceUpdateCommand command)
        {
            var invoice = _invoiceRepository.GetById(command.Id);
            if (invoice == null)
                throw new NotFoundException();
            Mapper.Map(invoice, command);
            return _invoiceRepository.Update(invoice);
        }

        public bool Remove(InvoiceRemoveCommand command)
        {
            var isRemovedAll = true;
            foreach (int id in command.InvoicesId)
            {
                var isRemoved = _invoiceRepository.Remove(id);
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }

            return isRemovedAll;
        }

    
        public Invoice GetById(int id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return _invoiceRepository.GetById(id);
        }

        public IQueryable<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }
    }
}
