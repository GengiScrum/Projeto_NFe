using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public interface IProductRepository
    {
        Product Add(Product product);
        bool Update(Product product);
        bool Remove(int id);
        Product GetById(int id);
        IQueryable<Product> GetAll();
        IQueryable<Product> GetAll(int quantity);
    }
}