using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.ProductsSold;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceServiceTest
    {
        Invoice _invoice;

        Mock<IInvoiceRepository> _mockInvoiceRepository;
        Mock<IIssuedInvoiceRepository> _mockIssuedInvoiceRepository;
        InvoiceService _invoiceService;

        [SetUp]
        public void Initialize()
        {
            _invoice = new Invoice();
            _mockInvoiceRepository = new Mock<IInvoiceRepository>();
            _mockIssuedInvoiceRepository = new Mock<IIssuedInvoiceRepository>();
            _invoiceService = new InvoiceService(_mockInvoiceRepository.Object, _mockIssuedInvoiceRepository.Object);
        }

        #region Add Invoice
        [Test]
        public void Invoice_Service_Add_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            _mockInvoiceRepository.Setup(nfr => nfr.Add(_invoice)).Returns(_invoice);

            //Ação
            Invoice salvarInvoice = _invoiceService.Add(_invoice);

            //Verificar
            salvarInvoice.Should().Be(_invoice);
            _mockInvoiceRepository.Verify(nfr => nfr.Add(_invoice));
        }
        #endregion

        #region Update
        [Test]
        public void Invoice_Service_Update_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(nfr => nfr.Update(_invoice)).Returns(_invoice);

            //Ação
            Invoice updateInvoice = _invoiceService.Update(_invoice);

            //Verificar
            updateInvoice.Should().Be(_invoice);
            _mockInvoiceRepository.Verify(nfr => nfr.Update(_invoice));
        }
        
        [Test]
        public void Invoice_Service_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            _mockInvoiceRepository.Setup(nfr => nfr.Update(_invoice)).Returns(_invoice);

            //Ação
            Action act = () => _invoiceService.Update(_invoice);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetById

        [Test]
        public void Invoice_Service_GetById_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(nfr => nfr.GetById(_invoice.Id)).Returns(_invoice);

            //Ação
            Invoice pegarInvoice = _invoiceService.GetById(_invoice);

            //Verificar
            pegarInvoice.Should().Be(_invoice);
            _mockInvoiceRepository.Verify(nfr => nfr.GetById(_invoice.Id));
        }

        [Test]
        public void Invoice_Service_GetByIdIssuedInvoice_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithoutId();
            _invoice.Id = 1;
            _mockIssuedInvoiceRepository.Setup(nfr => nfr.GetById(_invoice)).Returns(_invoice);

            //Ação
            Invoice pegarInvoice = _invoiceService.GetByIdIssuedInvoice(_invoice);

            //Verificar
            pegarInvoice.Should().Be(_invoice);
            _mockIssuedInvoiceRepository.Verify(nfr => nfr.GetById(_invoice));
        }

        [Test]
        public void Invoice_Service_GetById_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            _mockInvoiceRepository.Setup(nfr => nfr.GetById(_invoice.Id)).Returns(_invoice);

            //Ação
            Action act = () => _invoiceService.GetById(_invoice);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void Invoice_Service_GetByIdIssuedInvoice_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithoutId();
            _mockIssuedInvoiceRepository.Setup(nfr => nfr.GetById(_invoice)).Returns(_invoice);

            //Ação
            Action act = () => _invoiceService.GetByIdIssuedInvoice(_invoice);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockIssuedInvoiceRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region GetById Todas

        [Test]
        public void Invoice_Service_GetAll_Sucessfully()
        {
            //Cenário

            _mockInvoiceRepository.Setup(nfr => nfr.GetAll()).Returns(new List<Invoice>() { _invoice });

            //Ação
            IEnumerable<Invoice> invoices = _invoiceService.GetAll();

            //Verificar
            invoices.Should().NotBeNull();
            invoices.First().Should().Be(_invoice);
            invoices.Count().Should().Be(1);
            _mockInvoiceRepository.Verify(nfr => nfr.GetAll());
        }

        [Test]
        public void Invoice_Service_GetByIdTodasIssuedInvoices_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithoutId();
            _invoice.Id = 1;
            _mockIssuedInvoiceRepository.Setup(nfr => nfr.GetAll()).Returns(new List<Invoice>() { _invoice });

            //Ação
            IEnumerable<Invoice> invoices = _invoiceService.GetByIdTodasIssuedInvoices();

            //Verificar
            invoices.Should().NotBeNull();
            invoices.First().Should().Be(_invoice);
            invoices.Count().Should().Be(1);
            _mockIssuedInvoiceRepository.Verify(nfr => nfr.GetAll());
        }

        #endregion

        #region Remove

        [Test]
        public void Invoice_Service_Remove_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(nfr => nfr.Remove(_invoice.Id));

            //Ação
            Action act = () => _invoiceService.Remove(_invoice);

            //Verificar
            act.Should().NotThrow<IdentifierUndefinedException>();
            _mockInvoiceRepository.Verify(nfr => nfr.Remove(_invoice.Id));
        }

        [Test]
        public void Invoice_Service_Remove_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            _mockInvoiceRepository.Setup(nfr => nfr.Remove(_invoice.Id));

            //Ação
            Action act = () => _invoiceService.Remove(_invoice);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceRepository.VerifyNoOtherCalls();
        }
        #endregion

        #region Issue
        [Test]
        public void Invoice_Service_Issue_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(nfr => nfr.Remove(_invoice.Id));
            _mockIssuedInvoiceRepository.Setup(nfer => nfer.Add(_invoice));

            //Ação
            Action act = () => _invoiceService.Issue(_invoice);

            //Verificar
            act.Should().NotThrow();
            _mockIssuedInvoiceRepository.Verify(nfer => nfer.Add(_invoice));
            _mockInvoiceRepository.Verify(nfr => nfr.Remove(_invoice.Id));
        }

        [Test]
        public void Invoice_Service_IssueComChaveDeAcessoExistente_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(nfr => nfr.Remove(_invoice.Id));
            _mockIssuedInvoiceRepository.Setup(nfer => nfer.Add(_invoice));
            _mockIssuedInvoiceRepository.SetupSequence(nfer => nfer.CheckAcessKey(It.IsAny<string>())).Returns(true).Returns(false);

            //Ação
            Action act = () => _invoiceService.Issue(_invoice);

            //Verificar
            act.Should().NotThrow();
            _mockIssuedInvoiceRepository.Verify(nfer => nfer.CheckAcessKey(It.IsAny<string>()));
            _mockIssuedInvoiceRepository.Verify(nfer => nfer.Add(_invoice));
            _mockInvoiceRepository.Verify(nfr => nfr.Remove(_invoice.Id));
        }
        
        [Test]
        public void Invoice_Service_Issue_ShouldThrowIdentifierUndefinedException()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            _mockInvoiceRepository.Setup(nfr => nfr.Remove(_invoice.Id));
            _mockIssuedInvoiceRepository.Setup(nfer => nfer.Add(_invoice));

            //Ação
            Action act = () => _invoiceService.Issue(_invoice);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockIssuedInvoiceRepository.VerifyNoOtherCalls();
            _mockInvoiceRepository.VerifyNoOtherCalls();
        }
        #endregion

        [TearDown]
        public void Finalize()
        {
            _invoice = null;
            _invoiceService = null;
            _mockIssuedInvoiceRepository = null;
            _mockInvoiceRepository = null;
        }
    }
}
