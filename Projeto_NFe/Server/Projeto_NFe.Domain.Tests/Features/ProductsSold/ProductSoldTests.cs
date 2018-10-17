using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.ProductsSold;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;

namespace Projeto_NFe.Domain.Tests.Features.ProductsSold
{
    [TestFixture]
    public class ProductSoldTests
    {
        ProductSold _productSold;

        [SetUp]
        public void Initialize()
        {
            _productSold = new ProductSold();
        }

        [Test]
        public void ProductSold_Domain_CalculateTax_Sucessfully()
        {
            //Arrange
            Mock<ProductTax> _mockProductTax = new Mock<ProductTax>();
            _mockProductTax.Object.IcmsAliquot = 4;
            _mockProductTax.Object.IpiAliquot = 10;

            _productSold = ObjectMother.ProductSoldFull(_mockProductTax.Object);

            //ação
            _productSold.CalculateTax();

            //verificação
            _productSold.Tax.IcmsValue.Should().Be(2);
            _productSold.Tax.IpiValue.Should().Be(5);
        }
    }
}
