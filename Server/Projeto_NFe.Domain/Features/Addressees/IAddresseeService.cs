using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addressees
{
    public interface IAddresseeService
    {

        Addressee Add(Addressee addressee);
        Addressee Update(Addressee addressee);
        void Remove(Addressee addressee);
        Addressee GetById(Addressee addressee);
        IEnumerable<Addressee> GetAll();

    }
}
