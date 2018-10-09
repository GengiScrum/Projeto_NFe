using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        IInvoiceRepository _invoiceRepository;
        IIssuedInvoiceRepository _issuedInvoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository, IIssuedInvoiceRepository issuedInvoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
            _issuedInvoiceRepository = issuedInvoiceRepository;
        }

        public Invoice Add(Invoice invoice)
        {
            invoice.Validate();
            return _invoiceRepository.Add(invoice);
        }

        public Invoice Update(Invoice invoice)
        {
            if (invoice.Id == 0)
                throw new IdentifierUndefinedException();

            invoice.Validate();
            return _invoiceRepository.Update(invoice);
        }

        public void Remove(Invoice invoice)
        {
            if (invoice.Id == 0)
                throw new IdentifierUndefinedException();

            invoice.Validate();
            _invoiceRepository.Remove(invoice.Id);
        }

        public void Issue(Invoice invoice)
        {
            if (invoice.Id == 0)
                throw new IdentifierUndefinedException();

            invoice.Validate();
            invoice.Issue();
            if (_issuedInvoiceRepository.CheckAcessKey(invoice.AcessKey))
                Issue(invoice);
            _issuedInvoiceRepository.Add(invoice);
            _invoiceRepository.Remove(invoice.Id);
        }

        public Invoice GetById(Invoice invoice)
        {
            if (invoice.Id == 0)
                throw new IdentifierUndefinedException();

            return _invoiceRepository.GetById(invoice.Id);
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _invoiceRepository.GetAll();
        }

        public Invoice GetByIdIssuedInvoice(Invoice invoice)
        {
            if (invoice.Id == 0)
                throw new IdentifierUndefinedException();
            return _issuedInvoiceRepository.GetById(invoice);
        }

        public IEnumerable<Invoice> GetByIdTodasIssuedInvoices()
        {
            return _issuedInvoiceRepository.GetAll();
        }
    }
}
