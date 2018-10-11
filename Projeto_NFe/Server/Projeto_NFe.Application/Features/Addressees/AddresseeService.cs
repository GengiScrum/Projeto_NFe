using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Features.Addressees.Commands;
using Projeto_NFe.Application.Features.Addressees.Querys;
using AutoMapper;

namespace Projeto_NFe.Application.Features.Addressees
{
    public class AddresseeService : IAddresseeService
    {
        IAddresseeRepository _repository;

        public AddresseeService(IAddresseeRepository repository)
        {
            _repository = repository;
        }

        public int Add(AddresseeRegisterCommand command)
        {
            var addressee = Mapper.Map<AddresseeRegisterCommand, Addressee>(command);

            var newAddressee = _repository.Add(addressee);

            return newAddressee.Id;
        }

        public bool Update(AddresseeUpdateCommand command)
        {
            var addressee = _repository.GetById(command.Id);
            if (addressee == null)
                throw new NotFoundException();
            Mapper.Map(command, addressee);
            return _repository.Update(addressee);
        }

        public bool Remove(AddresseeRemoveCommand command)
        {
            var allRemoved = true;
            foreach (var addresseeId in command.AddresseesId)
            {
                var removed = _repository.Remove(addresseeId);
                allRemoved = removed ? allRemoved : false;
            }
            return allRemoved;
        }

        public Addressee GetById(int id)
        {
            var addressee = _repository.GetById(id);
            return addressee;
        }

        IQueryable<Addressee> IAddresseeService.GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<Addressee> GetAll(AddresseeQuery query)
        {
            return _repository.GetAll(query.Quantity);
        }
    }
}
