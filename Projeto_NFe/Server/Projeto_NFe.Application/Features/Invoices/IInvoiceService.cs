using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Application.Features.SoldProducts.Commands;
using Projeto_NFe.Application.Features.SoldProducts.Queries;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.SoldProducts;
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
        bool AddProduct(InvoiceAddProductCommand command);
        bool RemoveProducts(InvoiceRemoveProductsCommand command);
        bool Remove(InvoiceRemoveCommand command);
        Invoice GetById(int id);
        IQueryable<Invoice> GetAll();
        IQueryable<Invoice> GetAll(InvoiceQuery query);
        IQueryable<SoldProduct> GetAllSoldProducts(int id);
        IQueryable<SoldProduct> GetAllSoldProducts(SoldProductQuery query);
    }
}