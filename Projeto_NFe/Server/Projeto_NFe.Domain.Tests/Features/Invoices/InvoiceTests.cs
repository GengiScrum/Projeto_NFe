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
using Projeto_NFe.Application.Features.ProductsSold;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceTests
    {
        Mock<Issuer> _mockIssuer;
        Mock<ShippingCompany> _mockShippingCompany;
        Mock<Addressee> _mockAddressee;
        Mock<ProductSold> _mockProductSold;
        Mock<InvoiceTax> _mockInvoiceTax;
        Invoice _invoice;

        [SetUp]
        public void Initialize()
        {
            _mockIssuer = new Mock<Issuer>();
            _mockShippingCompany = new Mock<ShippingCompany>();
            _mockAddressee = new Mock<Addressee>();
            _mockProductSold = new Mock<ProductSold>();
            _mockInvoiceTax = new Mock<InvoiceTax>();
            _invoice = new Invoice();
        }

        [Test]
        public void Invoice_Domain_Validate_ShippingCompanyaValidate_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            //_mockShippingCompany.Setup(tr => tr.Validate());
            _mockIssuer.Object.BusinessName = "Issuer";
            _invoice.Issuer = _mockIssuer.Object;
            _invoice.ShippingCompany = _mockShippingCompany.Object;
            _invoice.Addressee = _mockAddressee.Object;
            _invoice.Products = new List<ProductSold>() { _mockProductSold.Object };

            //Ação
            _invoice.Validate();

            //Verificar
            //_mockShippingCompany.Verify(tr => tr.Validate());
        }

        [Test]
        public void Invoice_Domain_Validate_AddresseeValidate_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _mockAddressee.Setup(de => de.Validate());
            _mockIssuer.Object.BusinessName = "Issuer";
            _invoice.Issuer = _mockIssuer.Object;
            _invoice.ShippingCompany = _mockShippingCompany.Object;
            _invoice.Addressee = _mockAddressee.Object;
            _invoice.Products = new List<ProductSold>() { _mockProductSold.Object };

            //Ação
            _invoice.Validate();

            //Verificar
            _mockAddressee.Verify(de => de.Validate());
        }
        
        [Test]
        public void Invoice_Domain_Validate_ProductsValidate_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _mockProductSold.Setup(pv => pv.Validate());
            _mockIssuer.Object.BusinessName = "Issuer";
            _invoice.Issuer = _mockIssuer.Object;
            _invoice.ShippingCompany = _mockShippingCompany.Object;
            _invoice.Addressee = _mockAddressee.Object;
            _invoice.Products = new List<ProductSold>() { _mockProductSold.Object };

            //Ação
            _invoice.Validate();

            //Verificar
            _mockProductSold.Verify(pv => pv.Validate());
        }

        [Test]
        public void Invoice_Domain_CalculateTax_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _invoice.Products = new List<ProductSold>() { _mockProductSold.Object };
            _mockInvoiceTax.Setup(imnf => imnf.Calculate(_invoice.Products));
            _invoice.Tax = _mockInvoiceTax.Object;

            //Ação
            _invoice.CalculateTax();

            //Verificar
            _mockInvoiceTax.Verify(imnf => imnf.Calculate(_invoice.Products));
        }

        [Test]
        public void Invoice_Domain_IssueInvoice_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceWithoutIdNeedMock();
            _mockIssuer.Object.BusinessName = "Issuer";
            _invoice.Issuer = _mockIssuer.Object;
            _invoice.ShippingCompany = _mockShippingCompany.Object;
            _invoice.Addressee = _mockAddressee.Object;
            _mockInvoiceTax.Setup(imnf => imnf.Calculate(_invoice.Products));
            _invoice.Tax = _mockInvoiceTax.Object;
            _invoice.Products = new List<ProductSold>() { _mockProductSold.Object };

            //Ação
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
            _mockProductSold = null;
            _invoice = null;
        }
    }
}
