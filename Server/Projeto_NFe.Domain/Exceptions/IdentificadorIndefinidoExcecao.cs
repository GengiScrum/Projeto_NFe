using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Exceptions
{
    public class IdentifierUndefinedException : BusinessException
    {
        public IdentifierUndefinedException() : base(ErrorCodes.InvalidObject, "O Id não pode ser nulo ou vazio.")
        {
        }
    }
}
