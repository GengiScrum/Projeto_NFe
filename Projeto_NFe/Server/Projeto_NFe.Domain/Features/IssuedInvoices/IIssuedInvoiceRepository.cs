﻿using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.IssuedInvoices
{
    public interface IIssuedInvoiceRepository
    {
        Invoice Add(Invoice invoice);
        Invoice GetById(int id);
        IQueryable<Invoice> GetAll();
        bool ValidAccessKey(string chave);
    }
}
