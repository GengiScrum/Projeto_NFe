using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.ProductsSold;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Mock<ProductSold> _mockPrimeiroProductSold = new Mock<ProductSold>();
            Mock<ProductSold> _mockSegundoProductSold = new Mock<ProductSold>();
            Mock<ProductTax> _mockProductTax = new Mock<ProductTax>();

            _mockProductTax.Object.IcmsAliquot = 4;
            _mockProductTax.Object.IpiAliquot = 10;

            _mockPrimeiroProductSold.Object.Tax = _mockProductTax.Object;
            _mockPrimeiroProductSold.Object.Quantity = 2;
            _mockPrimeiroProductSold.Object.UnitaryValue = 25;

            _mockSegundoProductSold.Object.Tax = _mockProductTax.Object;
            _mockSegundoProductSold.Object.Quantity = 4;
            _mockSegundoProductSold.Object.UnitaryValue = 10;


            IEnumerable<ProductSold> listaProducts = new List<ProductSold> { _mockPrimeiroProductSold.Object, _mockSegundoProductSold.Object };

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
