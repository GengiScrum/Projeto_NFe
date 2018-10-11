using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.ProductTaxes;
using Projeto_NFe.Application.Features.ProductsSold;
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
        public void ProductSold_Domain_Validate_Sucessfully()
        {
            //Cenário
            Mock<ProductTax> _mockProductTax = new Mock<ProductTax>();
            _productSold = ObjectMother.ProductSoldFull(_mockProductTax.Object);

            //ação
            Action act = _productSold.Validate;

            //verificação
            act.Should().NotThrow();
        }

        [Test]
        public void ProductSold_Domain_CalculateTax_Sucessfully()
        {
            //Cenário
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
