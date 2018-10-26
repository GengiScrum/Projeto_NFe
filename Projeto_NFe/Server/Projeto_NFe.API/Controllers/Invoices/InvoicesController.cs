using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Application.Features.SoldProducts.Commands;
using Projeto_NFe.Application.Features.SoldProducts.Queries;
using Projeto_NFe.Application.Features.SoldProducts.ViewModels;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.SoldProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            var queryString = Request.GetQueryNameValuePairs()
                                                .Where(x => x.Key.Equals("size"))
                                                .FirstOrDefault();

            var query = default(IQueryable<Invoice>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _invoiceService.GetAll(new InvoiceQuery(size));
            }
            else
                query = _invoiceService.GetAll();

            return HandleQueryable<Invoice, InvoiceViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}/soldproducts")]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetSoldProductsByInvoiceId(ODataQueryOptions<SoldProduct> queryOptions, [FromUri]int id)
        {
            var queryStringSize = Request.GetQueryNameValuePairs()
                                                .Where(x => x.Key.Equals("size"))
                                                .FirstOrDefault();

            var queryResult = default(IQueryable<SoldProduct>);
            int size = 0;

            if (queryStringSize.Key != null && int.TryParse(queryStringSize.Value, out size))
            {
                queryResult = _invoiceService.GetAllSoldProducts(new SoldProductQuery(size, id));
            }
            else
                queryResult = _invoiceService.GetAllSoldProducts(id);


            return HandleQueryable<SoldProduct, SoldProductViewModel>(queryResult, queryOptions);
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
            var validator = invoiceCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceService.Add(invoiceCmd));
        }

        #region HttpPost
        [Route("soldproducts")]
        [HttpPost]
        public IHttpActionResult AddSoldProducts(InvoiceAddProductCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceService.AddProduct(command));
        }
        #endregion

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

        [Route("soldproducts")]
        [HttpDelete]
        public IHttpActionResult DeleteSoldProducts(InvoiceRemoveProductsCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_invoiceService.RemoveProducts(command));
        }

        #endregion HttpDelete
    }
}