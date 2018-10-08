using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Products;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            _mockProductRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Test]
        public void Product_Service_Add_Sucessfully()
        {
            //Cenário
            var product = ObjectMother.ProductValidWithoutId();
            var productCmd = ObjectMother.ProductCommandToRegister();
            _mockProductRepository.Setup(pr => pr.Add(It.IsAny<Product>())).Returns(product);

            //Ação
            var addProduct = _productService.Add(productCmd);

            //Verificar
            _mockProductRepository.Verify(pr => pr.Add(It.IsAny<Product>()), Times.Once);
            addProduct.Should().Be(product.Id);
        }

        [Test]
        public void Issuer_Service_Add_ShouldThrowException()
        {
            //Cenário
            var productCmd = ObjectMother.ProductCommandToRegister();
            _mockProductRepository.Setup(er => er.Add(It.IsAny<Product>())).Throws<Exception>();

            //Ação
            Action act = () => _productService.Add(productCmd);

            //Verificar
            act.Should().Throw<Exception>();
            _mockProductRepository.Verify(er => er.Add(It.IsAny<Product>()), Times.Once);
        }


        [Test]
        public void Product_Service_Update_Sucessfully()
        {
            //Cenário
            var product = ObjectMother.ProductValidWithId();
            var productCmd = ObjectMother.ProductCommandToUpdate();
            var eAtualizado = true;
            _mockProductRepository.Setup(e => e.GetById(productCmd.Id)).Returns(product);
            _mockProductRepository.Setup(er => er.Update(product)).Returns(eAtualizado);

            //Ação
            var updateProduct = _productService.Update(productCmd);

            //Verificar
            _mockProductRepository.Verify(e => e.GetById(productCmd.Id), Times.Once);
            _mockProductRepository.Verify(er => er.Update(product), Times.Once);
            updateProduct.Should().BeTrue();
        }

        [Test]
        public void Issuer_Service_Update_ShouldThrowNotFoundException()
        {
            //Cenário
            var productCmd = ObjectMother.ProductCommandToUpdate();
            _mockProductRepository.Setup(e => e.GetById(productCmd.Id)).Returns((Product)null);

            //Ação
            Action act = () => _productService.Update(productCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(e => e.GetById(productCmd.Id), Times.Once);
            _mockProductRepository.Verify(e => e.Update(It.IsAny<Product>()), Times.Never);
        }

        [Test]
        public void Product_Service_Remove_Sucessfully()
        {
            //Cenário
            var productCmd = ObjectMother.ProductCommandToRemove();
            var mockWasRemoved = true;
            _mockProductRepository.Setup(e => e.Remove(productCmd.ProductsId.First())).Returns(mockWasRemoved);

            //Ação
            var productRemoved = _productService.Remove(productCmd);

            //Verificar
            _mockProductRepository.Verify(e => e.Remove(productCmd.ProductsId.First()), Times.Once);
            productRemoved.Should().BeTrue();
        }

        [Test]
        public void Product_Service_Remove_ShouldThrowNotFoundException()
        {
            //Cenário
            var productCmd = ObjectMother.ProductCommandToRemove();
            _mockProductRepository.Setup(e => e.Remove(productCmd.ProductsId.First())).Throws<NotFoundException>();

            //Ação
            Action act = () => _productService.Remove(productCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(e => e.Remove(productCmd.ProductsId.First()), Times.Once);
        }

        [Test]
        public void Product_Service_GetById_Sucessfully()
        {
            //Cenário
            var product = ObjectMother.ProductValidWithId();
            _mockProductRepository.Setup(er => er.GetById(product.Id)).Returns(product);

            //Ação
            var pegarProduct = _productService.GetById(product.Id);

            //Verificar
            _mockProductRepository.Verify(er => er.GetById(product.Id), Times.Once);
            pegarProduct.Should().NotBeNull();
            pegarProduct.Id.Should().Be(product.Id);
        }

        [Test]
        public void Product_Service_GetById_ShouldThrowNotFoundException()
        {
            //Cenário
            var product = ObjectMother.ProductValidWithId();
            _mockProductRepository.Setup(pr => pr.GetById(product.Id)).Throws<NotFoundException>();

            //Ação
            Action act = () => _productService.GetById(product.Id);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(ps => ps.GetById(product.Id), Times.Once);
        }

        [Test]
        public void Product_Service_GetAll_Sucessfully()
        {
            //Cenário
            var product = ObjectMother.ProductValidWithId();
            var mockValueRepository = new List<Product>() { product }.AsQueryable();
            _mockProductRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Ação
            var productsResult = _productService.GetAll();

            //Verificar
            _mockProductRepository.Verify(er => er.GetAll(), Times.Once);
            productsResult.Should().NotBeNull();
            productsResult.First().Should().Be(product);
            productsResult.Count().Should().Be(mockValueRepository.Count());
        }
    }
}