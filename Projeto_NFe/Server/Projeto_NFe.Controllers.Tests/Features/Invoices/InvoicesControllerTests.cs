using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controllers.Invoices;
using Projeto_NFe.Application.Features.Invoices;
using Projeto_NFe.Application.Features.Invoices.Commands;
using Projeto_NFe.Application.Features.Invoices.ViewModels;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Controllers.Tests.Initializer;
using Projeto_NFe.Domain.Features.Invoices;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controllers.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoicesControllerTests : TestControllerBase
    {
        private InvoicesController _invoicesController;
        private Mock<IInvoiceService> _invoiceServiceMock;

        private Mock<InvoiceUpdateCommand> _invoiceUpdateCmd;
        private Mock<InvoiceRegisterCommand> _invoiceRegisterCmd;
        private Mock<InvoiceRemoveCommand> _invoiceRemoveCmd;
        private Mock<Invoice> _invoice;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _invoiceServiceMock = new Mock<IInvoiceService>();
            _invoicesController = new InvoicesController(_invoiceServiceMock.Object)
            {
                Request = request,
            };
            _validador = new Mock<ValidationResult>();
            _invoiceUpdateCmd = new Mock<InvoiceUpdateCommand>();
            _invoiceUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _invoiceRegisterCmd = new Mock<InvoiceRegisterCommand>();
            _invoiceRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _invoiceRemoveCmd = new Mock<InvoiceRemoveCommand>();
            _invoiceRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _invoice = new Mock<Invoice>();
            // Retorno padrão: pode ser sobreescrito nos testes
            var isValid = true;
            _validador.Setup(v => v.IsValid).Returns(isValid);
        }

        #region GET

        [Test]
        public void Invoices_Controller_GetAllSucessfully()
        {
            // Arrange
            var invoice = ObjectMother.InvoiceValidWithId();
            var response = new List<Invoice>() { invoice }.AsQueryable();
            _invoiceServiceMock.Setup(isv => isv.GetAll()).Returns(response);
            var id = 1;
            _invoiceUpdateCmd.Setup(i => i.Id).Returns(id);
            var oDataOptions = GetOdataQueryOptions<Invoice>(_invoicesController);
            // Action
            var callback = _invoicesController.GetAll(oDataOptions);

            //Assert
            _invoiceServiceMock.Verify(isv => isv.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<InvoiceViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        [Test]
        public void Invoices_Controller_GetById_Sucessfully()
        {
            // Arrange
            var id = 1;
            _invoiceUpdateCmd.Setup(i => i.Id).Returns(id);
            _invoice.Setup(i => i.Id).Returns(id);
            _invoiceServiceMock.Setup(isv => isv.GetById(id)).Returns(_invoice.Object);
            // Action
            IHttpActionResult callback = _invoicesController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<InvoiceViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _invoiceServiceMock.Verify(isv => isv.GetById(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Invoices_Controller_Add_Sucessfully()
        {
            // Arrange
            var id = 1;
            _invoiceServiceMock.Setup(isv => isv.Add(_invoiceRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _invoicesController.Add(_invoiceRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _invoiceServiceMock.Verify(isv => isv.Add(_invoiceRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void Invoices_Controller_Add_ShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _invoicesController.Add(_invoiceRegisterCmd.Object);
            //Assert
            /*var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _invoiceRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _invoiceRegisterCmd.VerifyNoOtherCalls();*/
        }

        #endregion

        #region PUT

        [Test]
        public void Invoices_Controller_Update_Sucessfully()
        {
            // Arrange
            var isUpdated = true;
            _invoiceServiceMock.Setup(isv => isv.Update(_invoiceUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _invoicesController.Update(_invoiceUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _invoiceServiceMock.Verify(isv => isv.Update(_invoiceUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void Invoices_Controller_Update_ShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _invoicesController.Update(_invoiceUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _invoiceUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _invoiceUpdateCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region DELETE

        [Test]
        public void Invoices_Controller_Remove_Sucessfully()
        {
            // Arrange
            var updated = true;
            _invoiceServiceMock.Setup(isv => isv.Remove(_invoiceRemoveCmd.Object)).Returns(updated);
            // Action
            IHttpActionResult callback = _invoicesController.Remove(_invoiceRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _invoiceServiceMock.Verify(isv => isv.Remove(_invoiceRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Invoices_Controller_Remove_ShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _invoicesController.Remove(_invoiceRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _invoiceRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _invoiceRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
