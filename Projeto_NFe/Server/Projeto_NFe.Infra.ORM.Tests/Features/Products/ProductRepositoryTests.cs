using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Infra.ORM.Features.Products;
using Projeto_NFe.Infra.ORM.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Products
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private FakeDbContext _context;
        private ProductRepository _repository;
        private Product _product;
        private Product _productBase;

        [SetUp]
        public void Setup()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _context = new FakeDbContext(connection);
            _repository = new ProductRepository(_context);
            _product = ObjectMother.ProductValidWithId();
            //Seed
            _productBase = ObjectMother.ProductValidWithId();
            _context.Products.Add(_productBase);
            _context.SaveChanges();
        }

        #region ADD
        [Test]
        public void Products_Repository_Add_Sucessfully()
        {
            //Ação
            var product = _repository.Add(_product);
            //Verificação
            product.Should().NotBeNull();
            product.Id.Should().NotBe(0);
            var expectedProduct = _context.Products.Find(product.Id);
            expectedProduct.Should().NotBeNull();
            expectedProduct.Should().Be(product);
        }

        #endregion

        #region GET

        [Test]
        public void Products_Repository_GetAll_Sucessfully()
        {
            //Ação
            var products = _repository.GetAll().ToList();

            //Assert
            products.Should().NotBeNull();
            products.Should().HaveCount(_context.Products.Count());
            products.First().Should().Be(_productBase);
        }

        [Test]
        public void Products_Repository_GetById_Sucessfully()
        {
            //Ação
            var product = _repository.GetById(_productBase.Id);

            //Assert
            product.Should().NotBeNull();
            product.Should().Be(_productBase);
        }

        #endregion

        #region DELETE
        [Test]
        public void Products_Repository_Remove_Sucessfully()
        {
            // Ação
            var removed = _repository.Remove(_productBase.Id);
            // Assert
            removed.Should().BeTrue();
            _context.Products.Where(p => p.Id == _productBase.Id).FirstOrDefault().Should().BeNull();
        }

        [Test]
        public void Products_Repository_Remove_ShouldThrowNotFoundException()
        {
            // Cenário
            var idInvalid = 10;
            // Ação
            Action act = () => _repository.Remove(idInvalid);
            // Verificação
            act.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Products_Repository_Update_Sucessfully()
        {
            // Cenário
            var modified = false;
            var newDescription = "Alterado";
            _productBase.Description = newDescription;
            //Ação
            var act = new Action(() => { modified = _repository.Update(_productBase); });
            // Verificação
            act.Should().NotThrow<Exception>();
            modified.Should().BeTrue();
        }
        #endregion
    }
}
