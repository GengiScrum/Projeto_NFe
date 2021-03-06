﻿using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Infra.ORM.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Invoices
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private NFeContext _context;

        public InvoiceRepository(NFeContext context)
        {
            _context = context;
        }
        public Invoice Add(Invoice invoice)
        {
            invoice = _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return invoice;
        }

        public IQueryable<Invoice> GetAll()
        {
            return _context.Invoices;
        }

        public IQueryable<Invoice> GetAll(int quantity)
        {
            return _context.Invoices.Take(quantity);
        }

        public IQueryable<SoldProduct> GetAllSoldProducts(int invoiceId)
        {
            return _context.SoldProducts.Where(sp => sp.InvoiceId == invoiceId);
        }

        public IQueryable<SoldProduct> GetAllSoldProducts(int quantity, int invoiceId)
        {
            return _context.SoldProducts.Where(sp => sp.InvoiceId == invoiceId).Take(quantity);
        }

        public Invoice GetById(int id)
        {
            return _context.Invoices.FirstOrDefault(invoice => invoice.Id == id);
        }

        public bool Remove(int id)
        {
            var invoice = _context.Invoices.FirstOrDefault(invoiceFind => invoiceFind.Id == id);
            if (invoice == null)
                throw new NotFoundException();
            _context.SoldProducts.RemoveRange(invoice.SoldProducts);
            _context.Entry(invoice).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public bool RemoveSoldProducts(int invoiceId, int[] soldProductsIds)
        {
            var invoiceToUpdate = GetById(invoiceId);
            foreach (var id in soldProductsIds)
            {
                var productToRemove = _context.SoldProducts.FirstOrDefault(sp => sp.Id == id);
                invoiceToUpdate.SoldProducts.Remove(productToRemove);
                _context.Entry(productToRemove).State = EntityState.Deleted;
            }
            _context.Entry(invoiceToUpdate).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Update(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
