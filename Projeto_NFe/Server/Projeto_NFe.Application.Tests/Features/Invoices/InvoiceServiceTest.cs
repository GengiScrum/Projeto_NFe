using FluentAssertions;
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
using Projeto_NFe.Application.Features.Invoices.Queries;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Application.Features.SoldProducts.Queries;

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

        #region Add
        [Test]
        public void Invoice_Service_Add_Sucessfully()
        {
            //Arrange
            var invoice = ObjectMother.InvoiceValidWithoutIdWithIssuerAddresseeShippingCompanyId(1, 1, 1);
            var invoiceCmd = ObjectMother.InvoiceCommandToRegister(1, 1, 1);
            _mockInvoiceRepository.Setup(ir => ir.Add(It.IsAny<Invoice>())).Returns(invoice);

            //Action
            var addInvoice = _invoiceService.Add(invoiceCmd);

            //Verificar
            _mockInvoiceRepository.Verify(ir => ir.Add(It.IsAny<Invoice>()));
            addInvoice.Should().Be(invoice.Id);
        }

        [Test]
        public void Invoice_Service_Add_ShouldThrowException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRegister(1, 1, 1);
            _mockInvoiceRepository.Setup(pr => pr.Add(It.IsAny<Invoice>())).Throws<Exception>();

            //Action
            Action act = () => _invoiceService.Add(invoiceCmd);

            //Assert
            act.Should().Throw<Exception>();
            _mockInvoiceRepository.Verify(pr => pr.Add(It.IsAny<Invoice>()), Times.Once);
        }

        [Test]
        public void Invoice_Service_AddProduct_Sucessfully()
        {
            //Arrange
            var invoice = ObjectMother.InvoiceValidWithId();
            var invoiceCmd = ObjectMother.InvoiceAddProductCommand();
            var updatedSuccessfully = true;
            _mockInvoiceRepository.Setup(ir => ir.GetById(It.IsAny<int>())).Returns(invoice);
            _mockInvoiceRepository.Setup(ir => ir.Update(It.IsAny<Invoice>())).Returns(updatedSuccessfully);

            //Action
            var updateResult = _invoiceService.AddProduct(invoiceCmd);

            //Verificar
            _mockInvoiceRepository.Verify(ir => ir.GetById(It.IsAny<int>()));
            _mockInvoiceRepository.Verify(ir => ir.Update(It.IsAny<Invoice>()));
            updateResult.Should().Be(updatedSuccessfully);
        }

        [Test]
        public void Invoice_Service_AddProduct_ShouldThrowNotFoundException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceAddProductCommand();

            //Action
            Action act = () => _invoiceService.AddProduct(invoiceCmd);

            //Verificar
            _mockInvoiceRepository.VerifyNoOtherCalls();
            act.Should().Throw<NotFoundException>();
        }
        #endregion

        #region Update
        [Test]
        public void Invoice_Service_Update_Sucessfully()
        {
            //Arrange
            var invoice = ObjectMother.InvoiceValidWithId();
            var invoiceCmd = ObjectMother.InvoiceCommandToUpdate(1, 1, 1);
            var updated = true;
            _mockInvoiceRepository.Setup(pr => pr.GetById(invoiceCmd.Id)).Returns(invoice);
            _mockInvoiceRepository.Setup(pr => pr.Update(invoice)).Returns(updated);

            //Action
            var updatedInvoice = _invoiceService.Update(invoiceCmd);

            //Verificar
            _mockInvoiceRepository.Verify(pr => pr.Update(invoice), Times.Once);
            _mockInvoiceRepository.Verify(pr => pr.GetById(invoiceCmd.Id), Times.Once);
            updatedInvoice.Should().BeTrue();
        }

        [Test]
        public void Invoice_Service_Update_ShouldThrowNotFoundException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToUpdate(1, 1, 1);
            _mockInvoiceRepository.Setup(pr => pr.GetById(invoiceCmd.Id)).Returns((Invoice)null);

            //Action
            Action act = () => _invoiceService.Update(invoiceCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockInvoiceRepository.Verify(pr => pr.GetById(invoiceCmd.Id), Times.Once);
            _mockInvoiceRepository.Verify(pr => pr.Update(It.IsAny<Invoice>()), Times.Never);
        }
        #endregion

        #region Remove

        [Test]
        public void Invoice_Service_Remove_Sucessfully()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRemove();
            var mockWasRemoved = true;
            _mockInvoiceRepository.Setup(pr => pr.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var invoiceRemoved = _invoiceService.Remove(invoiceCmd);

            //Assert
            _mockInvoiceRepository.Verify(pr => pr.Remove(It.IsAny<int>()), Times.Once);
            invoiceRemoved.Should().BeTrue();
        }

        [Test]
        public void Invoice_Service_Remove_ShouldThrowNotFoundException()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRemove();
            _mockInvoiceRepository.Setup(pr => pr.Remove(It.IsAny<int>())).Throws<NotFoundException>();

            //Action
            Action act = () => _invoiceService.Remove(invoiceCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _mockInvoiceRepository.Verify(pr => pr.Remove(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Invoice_Service_Remove_ReturnFalse()
        {
            //Arrange
            var invoiceCmd = ObjectMother.InvoiceCommandToRemove();
            var mockWasRemoved = false;
            _mockInvoiceRepository.Setup(e => e.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var removed = _invoiceService.Remove(invoiceCmd);

            //Assert
            _mockInvoiceRepository.Verify(e => e.Remove(It.IsAny<int>()), Times.Once);
            removed.Should().BeFalse();
        }

        [Test]
        public void Invoice_Service_RemoveProducts_Sucessfully()
        {
            //Arrange
            var cmd = ObjectMother.InvoiceRemoveProducstCommand();
            var mockWasRemoved = true;
            _mockInvoiceRepository.Setup(pr => pr.RemoveSoldProducts(cmd.Id, cmd.SoldProductsIds)).Returns(mockWasRemoved);

            //Action
            var removeResult = _invoiceService.RemoveProducts(cmd);

            //Assert
            _mockInvoiceRepository.Verify(pr => pr.RemoveSoldProducts(cmd.Id, cmd.SoldProductsIds), Times.Once);
            removeResult.Should().BeTrue();
        }

        [Test]
        public void Invoice_Service_RemoveProducts_ReturnFalse()
        {
            //Arrange
            var cmd = ObjectMother.InvoiceRemoveProducstCommand();
            var mockWasRemoved = false;
            _mockInvoiceRepository.Setup(pr => pr.RemoveSoldProducts(cmd.Id, cmd.SoldProductsIds)).Returns(mockWasRemoved);

            //Action
            var removeResult = _invoiceService.RemoveProducts(cmd);

            //Assert
            _mockInvoiceRepository.Verify(pr => pr.RemoveSoldProducts(cmd.Id, cmd.SoldProductsIds), Times.Once);
            removeResult.Should().BeFalse();
        }
        #endregion

        #region Get

        [Test]
        public void Invoice_Service_GetById_Sucessfully()
        {
            //Arrange
            var invoice = ObjectMother.InvoiceValidWithIdWithoutIssuerAddresseeShippingCompanyId();
            _mockInvoiceRepository.Setup(ir => ir.GetById(invoice.Id)).Returns(invoice);

            //Action
            var getInvoice = _invoiceService.GetById(invoice.Id);

            //Verificar
            getInvoice.Should().Be(invoice);
            _mockInvoiceRepository.Verify(ir => ir.GetById(invoice.Id));
        }

        [Test]
        public void Invoice_Service_GetById_ShouldThrowNotFoundException()
        {
            //Arrange
            var invoice = ObjectMother.InvoiceValidWithId();
            var exception = new NotFoundException();
            _mockInvoiceRepository.Setup(e => e.GetById(invoice.Id)).Throws(exception);

            //Action
            Action act = () => _invoiceService.GetById(invoice.Id);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockInvoiceRepository.Verify(e => e.GetById(invoice.Id), Times.Once);

        }

        [Test]
        public void Invoice_Service_GetById_ShouldThrowIdentifierUndefinedException()
        {
            //Arrange
            int undefinedId = 0;

            //Action
            Action act = () => _invoiceService.GetById(undefinedId);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _mockInvoiceRepository.VerifyNoOtherCalls();

        }

        [Test]
        public void Invoice_Service_GetAll_Sucessfully()
        {
            //Arrange

            _mockInvoiceRepository.Setup(ir => ir.GetAll()).Returns(new List<Invoice>() { _invoice }.AsQueryable());

            //Action
            IEnumerable<Invoice> invoices = _invoiceService.GetAll();

            //Verificar
            invoices.Should().NotBeNull();
            invoices.First().Should().Be(_invoice);
            invoices.Count().Should().Be(1);
            _mockInvoiceRepository.Verify(ir => ir.GetAll());
        }

        [Test]
        public void Invoice_Service_GetAllSoldProducts_Sucessfully()
        {
            //Arrange
            var soldProduct = ObjectMother.SoldProductValidWithId();
            _mockInvoiceRepository.Setup(ir => ir.GetAllSoldProducts(It.IsAny<int>())).Returns(new List<SoldProduct>() { soldProduct }.AsQueryable());

            //Action
            IEnumerable<SoldProduct> soldProducts = _invoiceService.GetAllSoldProducts(soldProduct.InvoiceId);

            //Verificar
            soldProducts.Should().NotBeNull();
            soldProducts.First().Should().Be(soldProduct);
            soldProducts.Count().Should().Be(1);
            _mockInvoiceRepository.Verify(ir => ir.GetAllSoldProducts(It.IsAny<int>()));
        }

        [Test]
        public void Invoice_Service_GetAllWithQuantity_Sucessfully()
        {
            //Arrange
            int quantity = 2;
            var invoice = ObjectMother.InvoiceValidWithId();
            var invoiceQuery = new Mock<InvoiceQuery>();
            invoiceQuery.Object.Quantity = quantity;
            var mockValueRepository = new List<Invoice>() { invoice, invoice }.AsQueryable();
            _mockInvoiceRepository.Setup(er => er.GetAll(It.IsAny<int>())).Returns(mockValueRepository);

            //Action
            var invoices = _invoiceService.GetAll(invoiceQuery.Object);

            //Assert
            _mockInvoiceRepository.Verify(er => er.GetAll(It.IsAny<int>()), Times.Once);
            invoices.Should().NotBeNull();
            invoices.First().Should().Be(invoice);
            invoices.Count().Should().Be(mockValueRepository.Count());
        }

        [Test]
        public void Invoice_Service_GetAllSoldProductsWithQuantity_Sucessfully()
        {
            //Arrange
            int quantity = 2;
            var soldProduct = ObjectMother.SoldProductValidWithId();
            var soldProductQuery = new SoldProductQuery(quantity, soldProduct.InvoiceId);
            var mockValueRepository = new List<SoldProduct>() { soldProduct, soldProduct }.AsQueryable();
            _mockInvoiceRepository.Setup(ir => ir.GetAllSoldProducts(quantity, It.IsAny<int>())).Returns(mockValueRepository);

            //Action
            var soldProducts = _invoiceService.GetAllSoldProducts(soldProductQuery);

            //Assert
            _mockInvoiceRepository.Verify(ir => ir.GetAllSoldProducts(quantity, It.IsAny<int>()), Times.Once);
            soldProducts.Should().NotBeNull();
            soldProducts.First().Should().Be(soldProduct);
            soldProducts.Count().Should().Be(mockValueRepository.Count());
        }
        #endregion
    }
}
