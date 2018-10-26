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
using Projeto_NFe.Application.Features.Products.Queries;

namespace Projeto_NFe.Application.Tests.Features.Products
{
    [TestFixture]
    public class ProductServiceTests
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

        #region Add

        [Test]
        public void Product_Service_Add_Sucessfully()
        {
            //Arrange 
            var product = ObjectMother.ProductValidWithId();
            var productCmd = ObjectMother.ProductCommandToRegister();
            _mockProductRepository.Setup(pr => pr.Add(It.IsAny<Product>())).Returns(product);

            //Action
            var addProduct = _productService.Add(productCmd);

            //Assert
            _mockProductRepository.Verify(pr => pr.Add(It.IsAny<Product>()), Times.Once);
            addProduct.Should().Be(product.Id);
        }

        [Test]
        public void Product_Service_Add_ShouldThrowException()
        {
            //Arrange
            var productCmd = ObjectMother.ProductCommandToRegister();
            _mockProductRepository.Setup(pr => pr.Add(It.IsAny<Product>())).Throws<Exception>();

            //Action
            Action act = () => _productService.Add(productCmd);

            //Assert
            act.Should().Throw<Exception>();
            _mockProductRepository.Verify(pr => pr.Add(It.IsAny<Product>()), Times.Once);
        }

        #endregion

        #region Update

        [Test]
        public void Product_Service_Update_Sucessfully()
        {
            //Arrange
            var product = ObjectMother.ProductValidWithId();
            var productCmd = ObjectMother.ProductCommandToUpdate();
            var updated = true;
            _mockProductRepository.Setup(pr => pr.GetById(productCmd.Id)).Returns(product);
            _mockProductRepository.Setup(pr => pr.Update(product)).Returns(updated);

            //Action
            var updateProduct = _productService.Update(productCmd);

            //Assert
            _mockProductRepository.Verify(pr => pr.GetById(productCmd.Id), Times.Once);
            _mockProductRepository.Verify(pr => pr.Update(product), Times.Once);
            updateProduct.Should().BeTrue();
        }

        [Test]
        public void Product_Service_Update_ShouldThrowNotFoundException()
        {
            //Arrange
            var productCmd = ObjectMother.ProductCommandToUpdate();
            _mockProductRepository.Setup(pr => pr.GetById(productCmd.Id)).Returns((Product)null);

            //Action
            Action act = () => _productService.Update(productCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(pr => pr.GetById(productCmd.Id), Times.Once);
            _mockProductRepository.Verify(pr => pr.Update(It.IsAny<Product>()), Times.Never);
        }

        #endregion

        #region Remove

        [Test]
        public void Product_Service_Remove_Sucessfully()
        {
            //Arrange
            var productCmd = ObjectMother.ProductCommandToRemove();
            var mockWasRemoved = true;
            _mockProductRepository.Setup(pr => pr.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var productRemoved = _productService.Remove(productCmd);

            //Assert
            _mockProductRepository.Verify(pr => pr.Remove(It.IsAny<int>()), Times.Once);
            productRemoved.Should().BeTrue();
        }

        [Test]
        public void Product_Service_Remove_ReturnFalse()
        {
            //Arrange
            var productCmd = ObjectMother.ProductCommandToRemove();
            var mockWasRemoved = false;
            _mockProductRepository.Setup(e => e.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var removed = _productService.Remove(productCmd);

            //Assert
            _mockProductRepository.Verify(e => e.Remove(It.IsAny<int>()), Times.Once);
            removed.Should().BeFalse();
        }

        [Test]
        public void Product_Service_Remove_ShouldThrowNotFoundException()
        {
            //Arrange
            var productCmd = ObjectMother.ProductCommandToRemove();
            _mockProductRepository.Setup(pr => pr.Remove(It.IsAny<int>())).Throws<NotFoundException>();

            //Action
            Action act = () => _productService.Remove(productCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(pr => pr.Remove(It.IsAny<int>()), Times.Once);
        }

        #endregion

        #region Get

        [Test]
        public void Product_Service_GetById_Sucessfully()
        {
            //Arrange
            var product = ObjectMother.ProductValidWithId();
            _mockProductRepository.Setup(pr => pr.GetById(product.Id)).Returns(product);

            //Action
            var getProduct = _productService.GetById(product.Id);

            //Assert
            _mockProductRepository.Verify(pr => pr.GetById(product.Id), Times.Once);
            getProduct.Should().NotBeNull();
            getProduct.Id.Should().Be(product.Id);
        }

        [Test]
        public void Product_Service_GetById_ShouldThrowNotFoundException()
        {
            //Arrange
            var product = ObjectMother.ProductValidWithoutId();
            var exception = new NotFoundException();
            _mockProductRepository.Setup(pr => pr.GetById(product.Id)).Throws(exception);

            //Action
            Action act = () => _productService.GetById(product.Id);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockProductRepository.Verify(pr => pr.GetById(product.Id), Times.Once);
        }

        [Test]
        public void Product_Service_GetAll_Sucessfully()
        {
            //Arrange
            var product = ObjectMother.ProductValidWithId();
            var mockValueRepository = new List<Product>() { product }.AsQueryable();
            _mockProductRepository.Setup(pr => pr.GetAll()).Returns(mockValueRepository);

            //Action
            var products = _productService.GetAll();

            //Assert
            _mockProductRepository.Verify(pr => pr.GetAll(), Times.Once);
            products.Should().NotBeNull();
            products.First().Should().Be(product);
            products.Count().Should().Be(mockValueRepository.Count());
        }

        [Test]
        public void Product_Service_GetAllWithQuantity_Sucessfully()
        {
            //Arrange
            int quantity = 2;
            var product = ObjectMother.ProductValidWithId();
            var productQuery = new Mock<ProductQuery>();
            productQuery.Object.Quantity = quantity;
            var mockValueRepository = new List<Product>() { product, product }.AsQueryable();
            _mockProductRepository.Setup(er => er.GetAll(It.IsAny<int>())).Returns(mockValueRepository);

            //Action
            var products = _productService.GetAll(productQuery.Object);

            //Assert
            _mockProductRepository.Verify(er => er.GetAll(It.IsAny<int>()), Times.Once);
            products.Should().NotBeNull();
            products.First().Should().Be(product);
            products.Count().Should().Be(mockValueRepository.Count());
        }

        #endregion
    }
}