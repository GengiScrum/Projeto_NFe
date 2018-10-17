using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Moq;
using NUnit.Framework;
using Projeto_NFe.API.Controllers.Addressees;
using Projeto_NFe.Application.Features.Addressees;
using Projeto_NFe.Application.Features.Addressees.Commands;
using Projeto_NFe.Application.Features.Addressees.ViewModel;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Controllers.Tests.Initializer;
using Projeto_NFe.Domain.Features.Addressees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Projeto_NFe.Controllers.Tests.Features.Addressees
{
    [TestFixture]
    public class AddresseesControllerTests : TestControllerBase
    {
        private AddresseesController _addresseesController;
        private Mock<IAddresseeService> _addresseeServiceMock;

        private Mock<AddresseeUpdateCommand> _addresseeUpdateCmd;
        private Mock<AddresseeRegisterCommand> _addresseeRegisterCmd;
        private Mock<AddresseeRemoveCommand> _addresseeRemoveCmd;
        private Mock<Addressee> _addressee;
        private Mock<ValidationResult> _validador;

        [SetUp]
        public void Initialize()
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            _addresseeServiceMock = new Mock<IAddresseeService>();
            _addresseesController = new AddresseesController(_addresseeServiceMock.Object)
            {
                Request = request,
            };
            _validador = new Mock<ValidationResult>();
            _addresseeUpdateCmd = new Mock<AddresseeUpdateCommand>();
            _addresseeUpdateCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _addresseeRegisterCmd = new Mock<AddresseeRegisterCommand>();
            _addresseeRegisterCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _addresseeRemoveCmd = new Mock<AddresseeRemoveCommand>();
            _addresseeRemoveCmd.Setup(cmd => cmd.Validate()).Returns(_validador.Object);
            _addressee = new Mock<Addressee>();
            var valid = true;
            _validador.Setup(v => v.IsValid).Returns(valid);
        }

        #region GET

        [Test]
        public void AddresseesController_Get_ShouldOk()
        {
            // Arrange
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            var response = new List<Addressee>() { addressee }.AsQueryable();
            _addresseeServiceMock.Setup(s => s.GetAll()).Returns(response);
            var id = 1;
            _addresseeUpdateCmd.Setup(a => a.Id).Returns(id);
            var odataOptions = GetOdataQueryOptions<Addressee>(_addresseesController);
            // Action
            var callback = _addresseesController.GetAll(odataOptions);

            //Assert
            _addresseeServiceMock.Verify(s => s.GetAll(), Times.Once);
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<PageResult<AddresseeViewModel>>>().Subject;
            httpResponse.Content.Should().NotBeNullOrEmpty();
            httpResponse.Content.First().Id.Should().Be(id);
        }

        [Test]
        public void AddresseesController_GetById_Sucessfully()
        {
            // Arrange
            var id = 1;
            _addresseeUpdateCmd.Setup(a => a.Id).Returns(id);
            _addressee.Setup(a => a.Id).Returns(id);
            _addresseeServiceMock.Setup(c => c.GetById(id)).Returns(_addressee.Object);
            // Action
            IHttpActionResult callback = _addresseesController.GetById(id);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<AddresseeViewModel>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            httpResponse.Content.Id.Should().Be(id);
            _addresseeServiceMock.Verify(s => s.GetById(id), Times.Once);
        }

        #endregion

        #region POST

        [Test]
        public void AddresseesController_AddSucessfully()
        {
            // Arrange
            var id = 1;
            _addresseeServiceMock.Setup(c => c.Add(_addresseeRegisterCmd.Object)).Returns(id);
            // Action
            IHttpActionResult callback = _addresseesController.Add(_addresseeRegisterCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<int>>().Subject;
            httpResponse.Content.Should().Be(id);
            _addresseeServiceMock.Verify(s => s.Add(_addresseeRegisterCmd.Object), Times.Once);
        }

        [Test]
        public void AddresseesController_AddShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _addresseesController.Add(_addresseeRegisterCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _addresseeRegisterCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _addresseeRegisterCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region PUT

        [Test]
        public void AddresseesController_Update_Sucessfully()
        {
            // Arrange
            var isUpdated = true;
            _addresseeServiceMock.Setup(c => c.Update(_addresseeUpdateCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _addresseesController.Update(_addresseeUpdateCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            httpResponse.Content.Should().BeTrue();
            _addresseeServiceMock.Verify(s => s.Update(_addresseeUpdateCmd.Object), Times.Once);
        }

        [Test]
        public void AddresseesController_Update_ShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _addresseesController.Update(_addresseeUpdateCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _addresseeUpdateCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _addresseeUpdateCmd.VerifyNoOtherCalls();
        }

        #endregion

        #region DELETE

        [Test]
        public void AddresseesController_Remove_Sucessfully()
        {
            // Arrange
            var isUpdated = true;
            _addresseeServiceMock.Setup(c => c.Remove(_addresseeRemoveCmd.Object)).Returns(isUpdated);
            // Action
            IHttpActionResult callback = _addresseesController.Remove(_addresseeRemoveCmd.Object);
            // Assert
            var httpResponse = callback.Should().BeOfType<OkNegotiatedContentResult<bool>>().Subject;
            _addresseeServiceMock.Verify(s => s.Remove(_addresseeRemoveCmd.Object), Times.Once);
            httpResponse.Content.Should().BeTrue();
        }

        [Test]
        public void AddresseesController_Remove_ShouldHandleValidationErrors()
        {
            //Arrange
            var isValid = false;
            _validador.Setup(v => v.IsValid).Returns(isValid);
            // Action
            var callback = _addresseesController.Remove(_addresseeRemoveCmd.Object);
            //Assert
            var httpResponse = callback.Should().BeOfType<NegotiatedContentResult<IList<ValidationFailure>>>().Subject;
            httpResponse.Content.Should().NotBeNull();
            _addresseeRemoveCmd.Verify(cmd => cmd.Validate(), Times.Once);
            _addresseeRemoveCmd.VerifyNoOtherCalls();
        }

        #endregion
    }
}
