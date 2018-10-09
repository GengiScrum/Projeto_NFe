using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.ORM.Contexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Infra.ORM.Features.ShippingCompanies
{
    public class ShippingCompanyRepository : IShippingCompanyRepository
    {
        NFeContext _context;

        public ShippingCompanyRepository(NFeContext context)
        {
            _context = context;
        }

        public bool Update(ShippingCompany shippingCompany)
        {
            _context.Entry(shippingCompany).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var shippingCompany = _context.ShippingCompanies.Where(t => t.Id == id).FirstOrDefault();
            if (shippingCompany == null)
                throw new NotFoundException();
            _context.Entry(shippingCompany).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public ShippingCompany GetById(int id)
        {
            return _context.ShippingCompanies.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<ShippingCompany> GetAll()
        {
            return _context.ShippingCompanies;
        }

        public IQueryable<ShippingCompany> GetAll(int quantity)
        {
            return _context.ShippingCompanies.Take(quantity);
        }

        public ShippingCompany Add(ShippingCompany shippingCompany)
        {
            var newShippingCompany = _context.ShippingCompanies.Add(shippingCompany);
            _context.SaveChanges();
            return newShippingCompany;
        }
    }
}
