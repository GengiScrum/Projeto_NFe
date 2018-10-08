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
        Addressee Update(Addressee addressee);
        void Remove(int id);
        Addressee GetById(int id);
        IEnumerable<Addressee> GetAll();
    }
}
