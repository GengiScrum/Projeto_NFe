using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.Issuers;
using Projeto_NFe.Application.Features.Issuers.Commands;
using Projeto_NFe.Application.Features.Issuers.Queries;
using Projeto_NFe.Application.Features.Issuers.ViewModel;
using Projeto_NFe.Domain.Features.Issuers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Projeto_NFe.API.Controllers.Issuers
{
    [RoutePrefix("api/issuers")]
    public class IssuersController : ApiControllerBase
    {
        private readonly IIssuerService _issuerService;

        public IssuersController(IIssuerService issuerService) : base()
        {
            _issuerService = issuerService;
        }

        #region HttpGet

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetAll(ODataQueryOptions<Issuer> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs()
                                                .Where(x => x.Key.Equals("size"))
                                                .FirstOrDefault();

            var query = default(IQueryable<Issuer>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _issuerService.GetAll(new IssuerQuery(size));
            }
            else
                query = _issuerService.GetAll();

            return HandleQueryable<Issuer, IssuerViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Issuer, IssuerViewModel>(_issuerService.GetById(id));
        }
        #endregion HttpGet

        #region HttpPost

        [HttpPost]
        public IHttpActionResult Add(IssuerRegisterCommand issuerCmd)
        {
            var validator = issuerCmd.Validate();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_issuerService.Add(issuerCmd));
        }

        #endregion HttpPost

        #region HttpPut

        [HttpPut]
        public IHttpActionResult Update(IssuerUpdateCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_issuerService.Update(command));
        }

        #endregion HttpPut

        #region HttpDelete

        [HttpDelete]
        public IHttpActionResult Remove(IssuerRemoveCommand command)
        {
            var validator = command.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(_issuerService.Remove(command));
        }

        #endregion HttpDelete
    }
}