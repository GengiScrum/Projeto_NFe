using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Infra.ORM.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Addressees
{
    public class AddresseReposiotory : IAddresseeRepository
    {
        private NFeContext _context;

        public AddresseReposiotory(NFeContext context)
        {
            _context = context;
        }

        public Addressee Add(Addressee addressee)
        {
            var mewAddressee = _context.Addressees.Add(addressee);
            _context.SaveChanges();
            return mewAddressee;
        }

        public IQueryable<Addressee> GetAll()
        {
            return _context.Addressees;
        }

        public IQueryable<Addressee> GetAll(int quantity)
        {
            return _context.Addressees.Take(quantity);
        }

        public Addressee GetById(int id)
        {
            return _context.Addressees.FirstOrDefault(e => e.Id == id);
        }

        public bool Remove(int id)
        {
            var addressee = _context.Addressees.FirstOrDefault(e => e.Id == id);
            if (addressee == null)
                throw new NotFoundException();
            _context.Entry(addressee).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public bool Update(Addressee addressee)
        {
            _context.Entry(addressee).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}
