using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addressees
{
    public interface IAddresseeRepository
    {
        Addressee Add(Addressee addressee);
        bool Update(Addressee addressee);
        bool Remove(int id);
        Addressee GetById(int id);
        IQueryable<Addressee> GetAll();
        IQueryable<Addressee> GetAll(int quantity);
    }
}
