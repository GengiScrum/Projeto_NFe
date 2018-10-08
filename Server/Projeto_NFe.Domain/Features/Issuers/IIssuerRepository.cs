using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Issuers
{
    public interface IIssuerRepository
    {
        Issuer Add(Issuer issuer);
        bool Update(Issuer issuer);
        bool Remove(int id);
        Issuer GetById(int id);
        IQueryable<Issuer> GetAll();
        IQueryable<Issuer> GetAll(int quantity);
    }
}
