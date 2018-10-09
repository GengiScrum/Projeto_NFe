using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.ViewModel;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Projeto_NFe.API.Controllers.Products
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService) : base()
        {
            _productService = productService;
        }

        #region HttpGet

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetAll(ODataQueryOptions<Product> queryOptions)
        {
            var query = _productService.GetAll();

            return HandleQueryable<Product, ProductViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Product, ProductViewModel>(_productService.GetById(id));
        }
        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        public IHttpActionResult Add(ProductRegisterCommand command)
        {
            var validator = command.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Add(command));
        }

        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        public IHttpActionResult Update(ProductUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        public IHttpActionResult Remove(ProductRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_productService.Remove(command));
        }

        #endregion HttpDelete
    }
}