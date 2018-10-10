using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controllers.Base;
using Projeto_NFe.API.Filters;
using Projeto_NFe.Application.Features.ShippingCompanies;
using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.Querys;
using Projeto_NFe.Application.Features.ShippingCompanies.ViewModel;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_NFe.API.Controllers.ShippingCompanies
{
    [RoutePrefix("api/shippingcompanies")]
    public class ShippingCompaniesController : ApiControllerBase
    {
        private readonly IShippingCompanyService _service;

        public ShippingCompaniesController(IShippingCompanyService service) : base()
        {
            _service = service;
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult GetAll(ODataQueryOptions<ShippingCompany> queryOptions)
        {
            var queryString = Request.GetQueryNameValuePairs()
                                                .Where(x => x.Key.Equals("size"))
                                                .FirstOrDefault();

            var query = default(IQueryable<ShippingCompany>);
            int size = 0;
            if (queryString.Key != null && int.TryParse(queryString.Value, out size))
            {
                query = _service.GetAll(new ShippingCompanyQuery(size));
            }
            else
                query = _service.GetAll();

            return HandleQueryable<ShippingCompany, ShippingCompanyViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleQuery<ShippingCompany, ShippingCompanyViewModel>(_service.GetById(id));
        }

        [HttpPost]
        public IHttpActionResult Add(ShippingCompanyRegisterCommand command)
        {
            var validador = command.Validate();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Add(command));
        }

        [HttpPut]
        public IHttpActionResult Update(ShippingCompanyUpdateCommand shippingCompany)
        {
            var validador = shippingCompany.Validate();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Update(shippingCompany));
        }

        [HttpDelete]
        public IHttpActionResult Remove(ShippingCompanyRemoveCommand shippingCompany)
        {
            var validador = shippingCompany.Validate();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(_service.Remove(shippingCompany));
        }

    }
}
