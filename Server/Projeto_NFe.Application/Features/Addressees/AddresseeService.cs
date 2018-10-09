using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addressees
{
    public class AddresseeService : IAddresseeService
    {
        IAddresseeRepository _repository;

        public AddresseeService(IAddresseeRepository repository)
        {
            _repository = repository;
        }

        public Addressee Add(Addressee addressee)
        {
            addressee.Validate();
            return _repository.Add(addressee);
        }

        public Addressee Update(Addressee addressee)
        {
            if (addressee.Id == 0) throw new IdentifierUndefinedException();
            addressee.Validate();
            return addressee;//_repository.Update(addressee);
        }

        public void Remove(Addressee addressee)
        {
            if (addressee.Id == 0) throw new IdentifierUndefinedException();
            _repository.Remove(addressee.Id);
        }

        public Addressee GetById(Addressee addressee)
        {
            if (addressee.Id == 0) throw new IdentifierUndefinedException();
            return _repository.GetById(addressee.Id);
        }

        public IEnumerable<Addressee> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
