using Projeto_NFe.Application.Features.Products.Commands;
using Projeto_NFe.Application.Features.Products.Queries;
using Projeto_NFe.Domain.Features.Products;
using System.Linq;

namespace Projeto_NFe.Application.Features.Products
{
    public interface IProductService
    {
        int Add(ProductRegisterCommand command);
        bool Update(ProductUpdateCommand command);
        bool Remove(ProductRemoveCommand command);
        Product GetById(int id);
        IQueryable<Product> GetAll();
        IQueryable<Product> GetAll(ProductQuery query);
    }
}