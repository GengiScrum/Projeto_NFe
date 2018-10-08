using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Domain.Exceptions;
using System.Linq;
using Projeto_NFe.Application.Features.Products.Commands;
using AutoMapper;
using Projeto_NFe.Application.Features.Products.Querys;

namespace Projeto_NFe.Application.Features.Products
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int Add(ProductRegisterCommand command)
        {
            var product = Mapper.Map<ProductRegisterCommand, Product>(command);

            var newProduct = _productRepository.Add(product);

            return newProduct.Id;
        }

        public bool Update(ProductUpdateCommand command)
        {
            var product = _productRepository.GetById(command.Id);
            if (product == null)
                throw new NotFoundException();
            Mapper.Map(command, product);
            return _productRepository.Update(product);
        }

        public bool Remove(ProductRemoveCommand command)
        {
            var removeAll = true;
            foreach (var productId in command.ProductsId)
            {
                var eRemovido = _productRepository.Remove(productId);
                removeAll = eRemovido ? removeAll : false;
            }
            return removeAll;
        }

        public Product GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;

        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IQueryable<Product> GetAll(ProductQuery query)
        {
            return _productRepository.GetAll(query.Quantity);
        }
    }
}
