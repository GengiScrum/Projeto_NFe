using AutoMapper;
using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.Queries;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Exceptions;
using System.Linq;

namespace Projeto_NFe.Application.Features.ShippingCompanies
{
    public class ShippingCompanyService : IShippingCompanyService
    {
        IShippingCompanyRepository _repository;

        public ShippingCompanyService(IShippingCompanyRepository repository)
        {
            _repository = repository;
        }

        public int Add(ShippingCompanyRegisterCommand command)
        {
            var shippingCompany = Mapper.Map<ShippingCompanyRegisterCommand, ShippingCompany>(command);

            var newShippingCompany = _repository.Add(shippingCompany);

            return newShippingCompany.Id;
        }

        public bool Update(ShippingCompanyUpdateCommand command)
        {
            var shippingCompany = _repository.GetById(command.Id);
            if (shippingCompany == null)
                throw new NotFoundException();
            Mapper.Map(command, shippingCompany);
            return _repository.Update(shippingCompany);
        }

        public bool Remove(ShippingCompanyRemoveCommand command)
        {
            var allRemoved = true;
            foreach (var shippingCompanyId in command.Ids)
            {
                var removed = _repository.Remove(shippingCompanyId);
                allRemoved = removed ? allRemoved : false;
            }
            return allRemoved;
        }

        public ShippingCompany GetById(int id)
        {
            var shippingCompany = _repository.GetById(id);
            return shippingCompany;
        }

        public IQueryable<ShippingCompany> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<ShippingCompany> GetAll(ShippingCompanyQuery query)
        {
            return _repository.GetAll(query.Quantity);
        }
    }
}
