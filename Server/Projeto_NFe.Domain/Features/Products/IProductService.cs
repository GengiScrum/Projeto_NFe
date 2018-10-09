using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Products
{
    public interface IProductService
    {
        Product Add(Product product);
        Product Update(Product product);
        void Remove(Product product);
        Product GetById(Product product);
        IEnumerable<Product> GetAll();
    }
}