using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ShippingCompanies
{
    public interface IShippingCompanyRepository
    {
        ShippingCompany Add(ShippingCompany shippingCompany);
        bool Update(ShippingCompany shippingCompany);
        bool Remove(int id);
        ShippingCompany GetById(int id);
        IQueryable<ShippingCompany> GetAll();
        IQueryable<ShippingCompany> GetAll(int quantity);
    }
}
