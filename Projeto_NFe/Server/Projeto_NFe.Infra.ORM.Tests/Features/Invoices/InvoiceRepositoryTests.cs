using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Features.Invoices;
using Projeto_NFe.Infra.ORM.Tests.Context;
using Projeto_NFe.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceRepositoryTests
    {
        private FakeDbContext _context;
        private InvoiceRepository _invoiceRepository;
        private Invoice _invoice;
        private Invoice _invoiceBase;
        private Issuer _issuerBase;
        private Addressee _addresseeBase;
        private ShippingCompany _shippingCompanyBase;

        [SetUp]
        public void Setup()
        {
            var conexao = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            _context = new FakeDbContext(conexao);
            _invoiceRepository = new InvoiceRepository(_context);

            //Seed

            //Adicionando o Issuer
            _issuerBase = _context.Issuers.Add(ObjectMother.IssuerValidWithoutIdAndWithAddress());
            //Adicionando o Shipping
            _shippingCompanyBase = _context.ShippingCompanies.Add(ObjectMother.ShippingCompanyValidWithoutIdWithAddress());
            //Adicionando o Addressee
            _addresseeBase = _context.Addressees.Add(ObjectMother.AddresseeValidWithoutIdWithAddress());
            //Adicionando o Invoice
            _invoiceBase = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(_issuerBase.Id, _shippingCompanyBase.Id, _addresseeBase.Id);
            _context.Invoices.Add(_invoiceBase);
            _context.SaveChanges();

            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(_issuerBase.Id, _shippingCompanyBase.Id, _addresseeBase.Id);
        }

        #region ADD
        [Test]
        public void Invoice_Repository_Add_Sucessfully()
        {

            //Arrange and action
            var invoice = _invoiceRepository.Add(_invoice);
            int idInvoiceAdded = 2;

            //Assert
            invoice.Should().NotBeNull();
            invoice.Id.Should().Be(idInvoiceAdded);
        }

        #endregion

        #region GET

        [Test]
        public void Invoice_Repository_GetAll_Sucessfully()
        {
            //Arrange and action
            var invoices = _invoiceRepository.GetAll().ToList();
            int quantityAddedsInvoices = 1;

            //Assert
            invoices.Should().NotBeNull();
            invoices.Should().HaveCount(quantityAddedsInvoices);
            invoices.First().Id.Should().Be(_invoiceBase.Id);
        }

        [Test]
        public void Invoice_Repository_GetById_Sucessfully()
        {
            //Arrange and action
            var invoiceFoundInDatabase = _invoiceRepository.GetById(_invoiceBase.Id);

            //Assert
            invoiceFoundInDatabase.Should().NotBeNull();
            invoiceFoundInDatabase.Id.Should().Be(_invoiceBase.Id);
        }

        #endregion

        #region DELETE
        [Test]
        public void Invoice_Repository_Remove_Sucessfully()
        {
            //Arrange and action
            var invoiceRemoved = _invoiceRepository.Remove(_invoiceBase.Id);
            int quantityInvoiceAfterRemove = 0;

            // Assert
            invoiceRemoved.Should().BeTrue();

            _context.Invoices.Count().Should().Be(quantityInvoiceAfterRemove);
        }

        [Test]
        public void Invoice_Repository_Remove_ShouldThrowNotFoundException()
        {
            // Cenário
            var idInvalid = 2;
            // Ação
            Action act = () => _invoiceRepository.Remove(idInvalid);
            // Verificação
            act.Should().Throw<NotFoundException>();
        }
        #endregion

        #region UPDATE

        [Test]
        public void Invoice_Repository_Update_Sucessfully()
        {
            // Arrange
            var isChanged = false;
            var operationNatureChanged = "invoice operationNature changed";
            _invoice.OperationNature = operationNatureChanged;

            //Action
            var invoiceChanged = new Action(() => isChanged = _invoiceRepository.Update(_invoiceBase));

            //Assert
            invoiceChanged.Should().NotThrow<Exception>();
            isChanged.Should().BeTrue();
        }
        #endregion

    }
}
