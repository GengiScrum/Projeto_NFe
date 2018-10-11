using Projeto_NFe.Application.Features.Addressees.Commands;
using Projeto_NFe.Application.Features.Addressees.Queries;
using Projeto_NFe.Domain.Features.Addressees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Addressees
{
    public interface IAddresseeService
    {
        int Add(AddresseeRegisterCommand command);
        bool Update(AddresseeUpdateCommand command);
        bool Remove(AddresseeRemoveCommand command);
        Addressee GetById(int id);
        IQueryable<Addressee> GetAll();
        IQueryable<Addressee> GetAll(AddresseeQuery query);
    }
}
