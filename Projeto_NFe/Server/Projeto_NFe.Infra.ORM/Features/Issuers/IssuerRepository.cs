using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Infra.ORM.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Issuers
{
    public class IssuerRepository : IIssuerRepository
    {
        private NFeContext _context;

        public IssuerRepository(NFeContext context)
        {
            _context = context;
        }

        public bool Update(Issuer issuer)
        {
            _context.Entry(issuer).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var issuer = _context.Issuers.FirstOrDefault(e => e.Id == id);
            if (issuer == null)
                throw new NotFoundException();
            _context.Entry(issuer).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public Issuer GetById(int id)
        {
            return _context.Issuers.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<Issuer> GetAll()
        {
            return _context.Issuers;
        }

        public IQueryable<Issuer> GetAll(int quantity)
        {
            return _context.Issuers.Take(quantity);
        }

        public Issuer Add(Issuer issuer)
        {
            var newIssuer = _context.Issuers.Add(issuer);
            _context.SaveChanges();
            return newIssuer;
        }
    }
}
