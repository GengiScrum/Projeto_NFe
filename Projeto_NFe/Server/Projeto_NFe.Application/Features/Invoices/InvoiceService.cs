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
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Application.Features.SoldProducts.Queries;

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
            var newInvoice = _invoiceRepository.Add(invoice);

            return newInvoice.Id;
        }

        public bool Update(InvoiceUpdateCommand command)
        {
            var invoice = _invoiceRepository.GetById(command.Id);
            if (invoice == null)
                throw new NotFoundException();
            Mapper.Map(command, invoice);
            return _invoiceRepository.Update(invoice);
        }

        public bool AddProduct(InvoiceAddProductCommand command)
        {
            var invoice = _invoiceRepository.GetById(command.Id);
            if (invoice == null)
                throw new NotFoundException();
            invoice.SoldProducts.Add(
                new SoldProduct
                {
                    InvoiceId = command.Id,
                    ProductId = command.SoldProduct.ProductId,
                    Quantity = command.SoldProduct.Quantity
                });

            return _invoiceRepository.Update(invoice);
        }

        public bool RemoveProducts(InvoiceRemoveProductsCommand command)
        {
            return _invoiceRepository.RemoveSoldProducts(command.Id, command.SoldProductsIds);
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

        public IQueryable<Invoice> GetAll(InvoiceQuery query)
        {
            return _invoiceRepository.GetAll(query.Quantity);
        }

        public IQueryable<SoldProduct> GetAllSoldProducts(int id)
        {
            return _invoiceRepository.GetAllSoldProducts(id);
        }

        public IQueryable<SoldProduct> GetAllSoldProducts(SoldProductQuery query)
        {
            return _invoiceRepository.GetAllSoldProducts(query.Quantity, query.InvoiceId);
        }

        #region Emitir Nota Fiscal

        //public void Issue(InvoiceIssueCommand cmd)
        //{
        //    if (cmd.Id == 0)
        //        throw new IdentifierUndefinedException();

        //    var invoice = _invoiceRepository.GetById(cmd.Id);
        //    invoice.Issue();
        //    if (!_issuedInvoiceRepository.ValidAccessKey(invoice.AcessKey))
        //    {
        //        Issue(cmd);
        //    }
        //    _issuedInvoiceRepository.Add(invoice);
        //    _invoiceRepository.Remove(invoice.Id);
        //}

        #endregion
    }
}
