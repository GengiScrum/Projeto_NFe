using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.Products;

namespace Projeto_NFe.Domain.Tests.Features.InvoiceTaxes
{
    [TestFixture]
    public class InvoiceTaxTests
    {
        InvoiceTax _taxInvoice;

        [SetUp]
        public void Initialize()
        {
            _taxInvoice = new InvoiceTax();
        }

        [Test]
        public void InvoiceTax_Domain_Calculate_Sucessfully()
        {
            //Arrange
            Mock<SoldProduct> _mockFirstSoldProduct = new Mock<SoldProduct>();
            Mock<Product> _mockFirstProduct = new Mock<Product>();
            Mock<Product> _mockSecondProduct = new Mock<Product>();
            Mock<SoldProduct> _mockSecondSoldProduct = new Mock<SoldProduct>();
            Mock<ProductTax> _mockProductTax = new Mock<ProductTax>();

            _mockProductTax.Object.IcmsAliquot = 4;
            _mockProductTax.Object.IpiAliquot = 10;

            _mockFirstProduct.Object.UnitaryValue = 25;
            _mockFirstSoldProduct.SetupGet(sp => sp.Product).Returns(_mockFirstProduct.Object);
            _mockFirstSoldProduct.Object.Product.Tax = _mockProductTax.Object;
            _mockFirstSoldProduct.Object.Quantity = 2;

            _mockSecondProduct.Object.UnitaryValue = 10;
            _mockSecondSoldProduct.SetupGet(sp => sp.Product).Returns(_mockSecondProduct.Object);
            _mockSecondSoldProduct.Object.Product.Tax = _mockProductTax.Object;
            _mockSecondSoldProduct.Object.Quantity = 4;


            IEnumerable<SoldProduct> listaProducts = new List<SoldProduct> { _mockFirstSoldProduct.Object, _mockSecondSoldProduct.Object };

            //Action
            _taxInvoice.Calculate(listaProducts);

            //Assert
            _taxInvoice.InvoiceIpiValue.Should().Be(9);
            _taxInvoice.InvoiceIcmsValue.Should().Be(3.6);
            _taxInvoice.ProductAmount.Should().Be(90);
            _taxInvoice.InvoiceAmount.Should().Be(102.6);
        }
    }
}
