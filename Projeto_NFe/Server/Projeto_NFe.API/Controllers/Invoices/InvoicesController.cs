﻿using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Projeto_NFe.API.Controllers.Invoices
{
    [RoutePrefix("api/invoices")]
    public class InvoicesController : ApiControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService) : base()
        {
            _invoiceService = invoiceService;
        }

        #region HttpGet

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetAll(ODataQueryOptions<Invoice> queryOptions)
        {
            var query = _invoiceService.GetAll();

            return HandleQueryable<Invoice, InvoiceViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Invoice, InvoiceViewModel>(_invoiceService.GetById(id));
        }
        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        public IHttpActionResult Add(InvoiceRegisterCommand invoiceCmd)
        {
            return HandleCallback(_invoiceService.Add(invoiceCmd));
        }

        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        public IHttpActionResult Update(InvoiceUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        public IHttpActionResult Remove(InvoiceRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceService.Remove(command));
        }

        #endregion HttpDelete
    }
}