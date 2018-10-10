using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.Addressees;
using Projeto_NFe.Application.Features.Addressees.Commands;
using Projeto_NFe.Application.Features.Addressees.Querys;
using Projeto_NFe.Application.Features.Addressees.ViewModel;
using Projeto_NFe.Domain.Features.Addressees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.API.Controllers.Addressees
{
    [RoutePrefix("api/addressees")]
    public class AddresseesController : ApiControllerBase
    {
        private readonly IAddresseeService _service;

        public AddresseesController(IAddresseeService service) : base()
        {
            _service = service;
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetAll(ODataQueryOptions<Addressee> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs()
                                                .Where(x => x.Key.Equals("size"))
                                                .FirstOrDefault();

            var query = default(IQueryable<Addressee>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _service.GetAll(new AddresseeQuery(size));
            }
            else
                query = _service.GetAll();

            return HandleQueryable<Addressee, AddresseeViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<Addressee, AddresseeViewModel>(_service.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Add(AddresseeRegisterCommand command)
        {
            var validador = command.Validate();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Add(command));
        }

        [HttpPut]
        public IHttpActionResult Update(AddresseeUpdateCommand command)
        {
            var validador = command.Validate();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Update(command));
        }

        [HttpDelete]
        public IHttpActionResult Remove(AddresseeRemoveCommand command)
        {
            var validador = command.Validate();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Remove(command));
        }
    }
}
