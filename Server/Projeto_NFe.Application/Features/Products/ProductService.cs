using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Add(Product product)
        {
            product.Validate();

            return _productRepository.Add(product);
        }

        public Product Update(Product product)
        {
            product.Validate();

            return product;
            //return _productRepository.Update(product);
        }

        public void Remove(Product product)
        {
            if (product.Id == 0)
                throw new IdentifierUndefinedException();

            _productRepository.Remove(product.Id);
        }

        public Product GetById(Product product)
        {
            if (product.Id == 0)
                throw new IdentifierUndefinedException();

            return _productRepository.GetById(product.Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}