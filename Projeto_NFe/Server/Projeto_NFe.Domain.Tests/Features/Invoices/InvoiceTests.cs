using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using Projeto_NFe.Domain.Features.ProductTaxes;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Features.SoldProducts;

namespace Projeto_NFe.Domain.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceTests
    {
        Mock<Issuer> _mockIssuer;
        Mock<ShippingCompany> _mockShippingCompany;
        Mock<Addressee> _mockAddressee;
        Mock<SoldProduct> _mockSoldProduct;
        Mock<InvoiceTax> _mockInvoiceTax;
        Invoice _invoice;

        [SetUp]
        public void Initialize()
        {
            _mockIssuer = new Mock<Issuer>();
            _mockShippingCompany = new Mock<ShippingCompany>();
            _mockAddressee = new Mock<Addressee>();
            _mockSoldProduct = new Mock<SoldProduct>();
            _mockInvoiceTax = new Mock<InvoiceTax>();
            _invoice = new Invoice();
        }

        [Test]
        public void Invoice_Domain_CalculateTax_Sucessfully()
        {
            //Arrange
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _invoice.SoldProducts = new List<SoldProduct>() { _mockSoldProduct.Object };
            _mockInvoiceTax.Setup(imnf => imnf.Calculate(_invoice.SoldProducts));
            _invoice.InvoiceTax = _mockInvoiceTax.Object;

            //Action
            _invoice.CalculateTax();

            //Verificar
            _mockInvoiceTax.Verify(imnf => imnf.Calculate(_invoice.SoldProducts));
        }

        [Test]
        public void Invoice_Domain_IssueInvoice_Sucessfully()
        {
            //Arrange
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _mockIssuer.Object.BusinessName = "Issuer";
            _invoice.Issuer = _mockIssuer.Object;
            _invoice.ShippingCompany = _mockShippingCompany.Object;
            _invoice.Addressee = _mockAddressee.Object;
            _mockInvoiceTax.Setup(imnf => imnf.Calculate(_invoice.SoldProducts));
            _invoice.InvoiceTax = _mockInvoiceTax.Object;
            _invoice.SoldProducts = new List<SoldProduct>() { _mockSoldProduct.Object };

            //Action
            _invoice.Issue();

            //Verificar
            _invoice.IssueDate.ToLongDateString().Should().Be(DateTime.Now.ToLongDateString());
            _invoice.IssueDate.ToLongTimeString().Should().Be(DateTime.Now.ToLongTimeString());
            _invoice.AcessKey.Should().NotBeEmpty();
        }

        [TearDown]
        public void Finalize()
        {
            _mockInvoiceTax = null;
            _mockIssuer = null;
            _mockShippingCompany = null;
            _mockAddressee = null;
            _mockSoldProduct = null;
            _invoice = null;
        }
    }
}
