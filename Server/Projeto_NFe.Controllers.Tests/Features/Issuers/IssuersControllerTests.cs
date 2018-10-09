using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controllers.Issuers;
using Projeto_NFe.Application.Features.Issuers;
using Projeto_NFe.Application.Features.Issuers.Commands;
using Projeto_NFe.Application.Features.Issuers.ViewModel;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Controllers.Tests.Initializer;
using Projeto_NFe.Domain.Features.Issuers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controllers.Tests.Features.Issuers
{
    [TestFixture]
    public class IssuersControllerTests : TestControllerBase
    {
        private IssuersController _issuersController;
        private Mock<IIssuerService> _issuerServiceMock;

        private Mock<IssuerUpdateCommand> _issuerUpdateCmd;
        private Mock<IssuerRegisterCommand> _issuerRegisterCmd;
        private Mock<IssuerRemoveCommand> _issuerRemoveCmd;
        private Mock<Issuer> _issuer;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _issuerServiceMock = new Mock<IIssuerService>();
            _issuersController = new IssuersController(_issuerServiceMock.Object)
            {
                Request = request,
            };
            _validador = new Mock<ValidationResult>();
            _issuerUpdateCmd = new Mock<IssuerUpdateCommand>();
            _issuerUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _issuerRegisterCmd = new Mock<IssuerRegisterCommand>();
            _issuerRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _issuerRemoveCmd = new Mock<IssuerRemoveCommand>();
            _issuerRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _issuer = new Mock<Issuer>();
            // Retorno padrão: pode ser sobreescrito nos testes
            var eValid = true;
            _validador.Setup(v => v.IsValid).Returns(eValid);
        }

        #region GET

        [Test]
        public void Issuers_Controller_GetAllSucessfully()
        {
            // Arrange
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var response = new List<Issuer>() { issuer }.AsQueryable();
            _issuerServiceMock.Setup(s => s.GetAll()).Returns(response);
            var id = 1;
            _issuerUpdateCmd.Setup(p => p.Id).Returns(id);
            var odataOptions = GetOdataQueryOptions<Issuer>(_issuersController);
            // Action
            var callback = _issuersController.GetAll(odataOptions);

            //Assert
            _issuerServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<IssuerViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        [Test]
        public void Issuers_Controller_GetById_Sucessfully()
        {
            // Arrange
            var id = 1;
            _issuerUpdateCmd.Setup(p => p.Id).Returns(id);
            _issuer.Setup(p => p.Id).Returns(id);
            _issuerServiceMock.Setup(c => c.GetById(id)).Returns(_issuer.Object);
            // Action
            IHttpActionResult callback = _issuersController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<IssuerViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _issuerServiceMock.Verify(s => s.GetById(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void Issuers_Controller_Add_Sucessfully()
        {
            // Arrange
            var id = 1;
            _issuerServiceMock.Setup(c => c.Add(_issuerRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _issuersController.Add(_issuerRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _issuerServiceMock.Verify(s => s.Add(_issuerRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void issuers_Controller_Add_DeveTratarErrosValidacao()
        {
            //Arrange
            var eValid = false;
            _validador.Setup(v => v.IsValid).Returns(eValid);
            // Action
            var callback = _issuersController.Add(_issuerRegisterCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _issuerRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _issuerRegisterCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void Issuers_Controller_Update_Sucessfully()
        {
            // Arrange
            var isUpdated = true;
            _issuerServiceMock.Setup(c => c.Update(_issuerUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _issuersController.Update(_issuerUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _issuerServiceMock.Verify(s => s.Update(_issuerUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void issuers_Controller_Update_DeveTratarErrosValidacao()
        {
            //Arrange
            var eValid = false;
            _validador.Setup(v => v.IsValid).Returns(eValid);
            // Action
            var callback = _issuersController.Update(_issuerUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _issuerUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _issuerUpdateCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region DELETE

        [Test]
        public void Issuers_Controller_Remove_Sucessfully()
        {
            // Arrange
            var eAtualizado = true;
            _issuerServiceMock.Setup(c => c.Remove(_issuerRemoveCmd.Object)).Returns(eAtualizado);
            // Action
            IHttpActionResult callback = _issuersController.Remove(_issuerRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _issuerServiceMock.Verify(s => s.Remove(_issuerRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void Issuers_Controller_Remove_DeveTratarErrosValidacao()
        {
            //Arrange
            var eValid = false;
            _validador.Setup(v => v.IsValid).Returns(eValid);
            // Action
            var callback = _issuersController.Remove(_issuerRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _issuerRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _issuerRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
