﻿using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Tests.Initializer;

namespace Projeto_NFe.Application.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceServiceTest : TestServiceBase
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
            _invoiceService = new InvoiceService(_mockInvoiceRepository.Object);
        }

        #region Add Invoice
        [Test]
        public void Invoice_Service_Add_Sucessfully()
        {
            //Cenário
            var invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            var invoiceCmd = ObjectMother.InvoiceCommandToRegister(1,1,1);
            _mockInvoiceRepository.Setup(ir => ir.Add(It.IsAny<Invoice>())).Returns(invoice);

            //Ação
            var addInvoice = _invoiceService.Add(invoiceCmd);

            //Verificar
            _mockInvoiceRepository.Verify(ir => ir.Add(It.IsAny<Invoice>()));
            addInvoice.Id.Should().Be(invoice.Id);
        }
        #endregion

        #region Update
        //[Test]
        //public void Invoice_Service_Update_Sucessfully()
        //{
        //    //Cenário
        //    var invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
        //    var invoiceCmd = ObjectMother.InvoiceCommandToUpdate(1,1,1);
        //    var updated = true;
        //    _mockInvoiceRepository.Setup(pr => pr.GetById(invoiceCmd.Id)).Returns(invoice);
        //    _mockInvoiceRepository.Setup(pr => pr.Update(invoice)).Returns(updated);

        //    //Ação
        //    var updateInvoice = _invoiceService.Update(invoiceCmd);

        //    //Verificar
        //    _mockInvoiceRepository.Verify(pr => pr.GetById(invoiceCmd.Id), Times.Once);
        //    _mockInvoiceRepository.Verify(pr => pr.Update(invoice), Times.Once);
        //    updateInvoice.Should().BeTrue();
        //}
        
        [Test]
        public void Invoice_Service_Update_ShouldThrowNotFoundException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToUpdate(1,1,1);
            _mockInvoiceRepository.Setup(pr => pr.GetById(invoiceCmd.Id)).Returns((Invoice)null);

            //Action
            Action act = () => _invoiceService.Update(invoiceCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockInvoiceRepository.Verify(pr => pr.GetById(invoiceCmd.Id), Times.Once);
            _mockInvoiceRepository.Verify(pr => pr.Update(It.IsAny<Invoice>()), Times.Never);
        }
        #endregion

        #region GetById

        [Test]
        public void Invoice_Service_GetById_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(ir => ir.GetById(_invoice.Id)).Returns(_invoice);

            //Ação
            Invoice pegarInvoice = _invoiceService.GetById(_invoice.Id);

            //Verificar
            pegarInvoice.Should().Be(_invoice);
            _mockInvoiceRepository.Verify(ir => ir.GetById(_invoice.Id));
        }

        #endregion

        #region GetById Todas

        [Test]
        public void Invoice_Service_GetAll_Sucessfully()
        {
            //Cenário

            _mockInvoiceRepository.Setup(ir => ir.GetAll()).Returns(new List<Invoice>() { _invoice }.AsQueryable());

            //Ação
            IEnumerable<Invoice> invoices = _invoiceService.GetAll();

            //Verificar
            invoices.Should().NotBeNull();
            invoices.First().Should().Be(_invoice);
            invoices.Count().Should().Be(1);
            _mockInvoiceRepository.Verify(ir => ir.GetAll());
        }

        #endregion

        #region Remove

        [Test]
        public void Invoice_Service_Remove_Sucessfully()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRemove();
            var mockWasRemoved = true;
            _mockInvoiceRepository.Setup(pr => pr.Remove(invoiceCmd.InvoicesId.First())).Returns(mockWasRemoved);

            //Action
            var invoiceRemoved = _invoiceService.Remove(invoiceCmd);

            //Assert
            _mockInvoiceRepository.Verify(pr => pr.Remove(invoiceCmd.InvoicesId.First()), Times.Once);
            invoiceRemoved.Should().BeTrue();
        }

        [Test]
        public void Invoice_Service_Remove_ShouldThrowIdentifierUndefinedException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRemove();
            _mockInvoiceRepository.Setup(pr => pr.Remove(invoiceCmd.InvoicesId.First())).Throws<NotFoundException>();

            //Action
            Action act = () => _invoiceService.Remove(invoiceCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockInvoiceRepository.Verify(pr => pr.Remove(invoiceCmd.InvoicesId.First()), Times.Once);
        }
        #endregion
    }
}
