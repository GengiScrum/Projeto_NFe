using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controllers.ShippingCompanies;
using Projeto_NFe.Application.Features.ShippingCompanies;
using Projeto_NFe.Application.Features.ShippingCompanies.Commands;
using Projeto_NFe.Application.Features.ShippingCompanies.ViewModel;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Controllers.Tests.Initializer;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controllers.Tests.Features.ShippingCompanies
{
    [TestFixture]
    public class ShippingCompaniesControllerTests : TestControllerBase
    {
        private ShippingCompaniesController _shippingCompanyController;
        private Mock<IShippingCompanyService> _transportadotServiceMock;

        private Mock<ShippingCompanyUpdateCommand> _shippingCompanyUpdateCmd;
        private Mock<ShippingCompanyRegisterCommand> _ShippingCompanytRegisterCmd;
        private Mock<ShippingCompanyRemoveCommand> _shippingCompanyRemoveCmd;
        private Mock<ShippingCompany> _shippingCompany;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage requisicao = new HttpRequestMessage();
            requisicao.SetConfiguration(new HttpConfiguration());
            _transportadotServiceMock = new Mock<IShippingCompanyService>();
            _shippingCompanyController = new ShippingCompaniesController(_transportadotServiceMock.Object)
            {
                Request = requisicao,
            };
            _validador = new Mock<ValidationResult>();
            _shippingCompanyUpdateCmd = new Mock<ShippingCompanyUpdateCommand>();
            _shippingCompanyUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _ShippingCompanytRegisterCmd = new Mock<ShippingCompanyRegisterCommand>();
            _ShippingCompanytRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _shippingCompanyRemoveCmd = new Mock<ShippingCompanyRemoveCommand>();
            _shippingCompanyRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _shippingCompany = new Mock<ShippingCompany>();
            // Retorno padrão: pode ser sobreescrito nos testes
            var valid = true;
            _validador.Setup(v => v.IsValid).Returns(valid);
        }

        #region GET

        [Test]
        public void Products_Controller_Get_ShouldOk()
        {
            // Arrange
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var resposta = new List<ShippingCompany>() { shippingCompany }.AsQueryable();
            _transportadotServiceMock.Setup(s => s.GetAll()).Returns(resposta);
            var id = 1;
            _shippingCompanyUpdateCmd.Setup(p => p.Id).Returns(id);
            var odataOptions = GetOdataQueryOptions<ShippingCompany>(_shippingCompanyController);
            // Action
            var callback = _shippingCompanyController.GetAll(odataOptions);

            //Assert
            _transportadotServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<ShippingCompanyViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        [Test]
        public void Products_Controller_GetById_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _shippingCompanyUpdateCmd.Setup(p => p.Id).Returns(id);
            _shippingCompany.Setup(p => p.Id).Returns(id);
            _transportadotServiceMock.Setup(c => c.GetById(id)).Returns(_shippingCompany.Object);
            // Action
            IHttpActionResult callback = _shippingCompanyController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<ShippingCompanyViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _transportadotServiceMock.Verify(s => s.GetById(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Products_Controller_Post_ShouldBeOk()
        {
            // Arrange
            var id = 1;
            _transportadotServiceMock.Setup(c => c.Add(_ShippingCompanytRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _shippingCompanyController.Add(_ShippingCompanytRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _transportadotServiceMock.Verify(s => s.Add(_ShippingCompanytRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void products_Controller_Post_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _shippingCompanyController.Add(_ShippingCompanytRegisterCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _ShippingCompanytRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _ShippingCompanytRegisterCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Products_Controller_Put_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _transportadotServiceMock.Setup(c => c.Update(_shippingCompanyUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _shippingCompanyController.Update(_shippingCompanyUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _transportadotServiceMock.Verify(s => s.Update(_shippingCompanyUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void products_Controller_Update_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _shippingCompanyController.Update(_shippingCompanyUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _shippingCompanyUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _shippingCompanyUpdateCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region DELETE

        [Test]
        public void Products_Controller_Delete_ShouldBeOk()
        {
            // Arrange
            var isUpdated = true;
            _transportadotServiceMock.Setup(c => c.Remove(_shippingCompanyRemoveCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _shippingCompanyController.Remove(_shippingCompanyRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _transportadotServiceMock.Verify(s => s.Remove(_shippingCompanyRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Products_Controller_Delete_ShouldBeHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _shippingCompanyController.Remove(_shippingCompanyRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _shippingCompanyRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _shippingCompanyRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
