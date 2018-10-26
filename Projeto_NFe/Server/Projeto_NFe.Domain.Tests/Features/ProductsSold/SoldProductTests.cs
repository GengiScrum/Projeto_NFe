using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Domain.Tests.Features.ProductsSold
{
    [TestFixture]
    public class SoldProductTests
    {
        SoldProduct _soldProduct;

        [SetUp]
        public void Initialize()
        {
            _soldProduct = new SoldProduct();
        }

        [Test]
        public void SoldProduct_Domain_CalculateTax_Sucessfully()
        {
            //Arrange
            Mock<ProductTax> _mockProductTax = new Mock<ProductTax>();
            _mockProductTax.Object.IcmsAliquot = 4;
            _mockProductTax.Object.IpiAliquot = 10;

            Mock<Product> _mockProduct = new Mock<Product>();
            _mockProduct.Object.UnitaryValue = 25;
            _mockProduct.Object.Tax = _mockProductTax.Object;

            _soldProduct = ObjectMother.SoldProductFull(_mockProduct.Object);

            //ação
            _soldProduct.CalculateTax();

            //verificação
            _soldProduct.Product.Tax.IcmsValue.Should().Be(2);
            _soldProduct.Product.Tax.IpiValue.Should().Be(5);
        }
    }
}
