using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Products;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Features.Products
{
    [TestFixture]
    public class ProductServiceTest
    {
        Product _product;
        Mock<IProductRepository> _mockProductRepository;
        ProductService _productService;

        [SetUp]
        public void Initialize()
        {
            _product = new Product();
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Test]
        public void Product_Service_Add_Sucessfully()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithoutId();
            _mockProductRepository.Setup(pr => pr.Add(_product)).Returns(_product);

            //Ação
            Product addProduct = _productService.Add(_product);

            //Verificar
            addProduct.Should().Be(_product);
            _mockProductRepository.Verify(pr => pr.Add(_product));
        }

        //[Test]
        //public void Product_Service_Update_Sucessfully()
        //{
        //    //Cenário
        //    _product = ObjectMother.ProductValidWithoutId();
        //    _mockProductRepository.Setup(pr => pr.Update(_product)).Returns(_product);

        //    //Ação
        //    Product updateProduct = _productService.Update(_product);

        //    //Verificar
        //    updateProduct.Should().Be(_product);
        //    _mockProductRepository.Verify(pr => pr.Update(_product));
        //}

        [Test]
        public void Product_Service_GetById_Sucessfully()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithId();
            _mockProductRepository.Setup(pr => pr.GetById(_product.Id)).Returns(_product);

            //Ação
            Product pegarProduct = _productService.GetById(_product);

            //Verificar
            _mockProductRepository.Verify(pr => pr.GetById(_product.Id));
            pegarProduct.Should().Be(_product);
        }

        [Test]
        public void Product_Service_GetById_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithoutId();
            _mockProductRepository.Setup(pr => pr.GetById(_product.Id)).Returns(_product);

            //Ação
            Action act = () => _productService.GetById(_product);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockProductRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Product_Service_GetAll_Sucessfully()
        {
            //Cenário
            IEnumerable<Product> products;
            _mockProductRepository.Setup(pr => pr.GetAll()).Returns(new List<Product>() { _product });

            //Ação
            products = _productService.GetAll();

            //Verificar
            _mockProductRepository.Verify(pr => pr.GetAll());
            products.First().Should().Be(_product);
        }

        [Test]
        public void Product_Service_Remove_Sucessfully()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithId();
            _mockProductRepository.Setup(pr => pr.Remove(_product.Id));

            //Ação
            Action act = () => _productService.Remove(_product);
            _productService.Remove(_product);

            //Verificar
            _mockProductRepository.Verify(pr => pr.Remove(_product.Id));
            act.Should().NotThrow<IdentifierUndefinedException>();
        }

        [Test]
        public void Product_Service_Remove_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithoutId();
            _mockProductRepository.Setup(pr => pr.Remove(_product.Id));

            //Ação
            Action act = () => _productService.Remove(_product);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockProductRepository.VerifyNoOtherCalls();
        }

        [TearDown]
        public void Finalize()
        {
            _product = null;
            _productService = null;
            _mockProductRepository = null;
        }
    }
}