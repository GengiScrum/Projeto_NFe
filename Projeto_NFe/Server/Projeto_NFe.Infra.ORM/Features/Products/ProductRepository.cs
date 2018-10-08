using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Infra.ORM.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Projeto_NFe.Infra.ORM.Features.Products
{
    public class ProductRepository
    {
        private NFeContext _context;

        public ProductRepository(NFeContext context)
        {
            _context = context;
        }

        public bool Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Remove(int id)
        {
            var product = _context.Products.FirstOrDefault(e => e.Id == id);
            if (product == null)
                throw new NotFoundException();
            _context.Entry(product).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public IQueryable<Product> GetAll(int quantity)
        {
            return _context.Products.Take(quantity);
        }

        public Product Add(Product product)
        {
            var newProduct = _context.Products.Add(product);
            _context.SaveChanges();
            return newProduct;
        }
    }
}
