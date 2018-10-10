using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.Querys;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies
{
    public interface IShippingCompanyService
    {
        int Add(ShippingCompanyRegisterCommand command);
        bool Update(ShippingCompanyUpdateCommand command);
        bool Remove(ShippingCompanyRemoveCommand command);
        ShippingCompany GetById(int id);
        IQueryable<ShippingCompany> GetAll();
        IQueryable<ShippingCompany> GetAll(ShippingCompanyQuery query);
    }
}
