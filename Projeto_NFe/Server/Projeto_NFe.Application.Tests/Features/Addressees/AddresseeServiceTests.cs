using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.Addressees;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Tests.Initializer;

namespace Projeto_NFe.Application.Tests.Features.Addressees
{
    [TestFixture]
    public class AddresseeServiceTests : TestServiceBase
    {
        IAddresseeService _addresseeService;
        Mock<IAddresseeRepository> _mockAddresseeRepository;

        [SetUp]
        public void Initialize()
        {
            _mockAddresseeRepository = new Mock<IAddresseeRepository>();
            _addresseeService = new AddresseeService(_mockAddresseeRepository.Object);
        }

        #region Add

        [Test]
        public void Addressee_Service_Add_Sucessfully()
        {
            //Arrange 
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            var addresseeCmd = ObjectMother.AddresseeCommandToRegister();
            _mockAddresseeRepository.Setup(er => er.Add(It.IsAny<Addressee>())).Returns(addressee);

            //Action
            var addAddressee = _addresseeService.Add(addresseeCmd);

            //Assert
            _mockAddresseeRepository.Verify(er => er.Add(It.IsAny<Addressee>()), Times.Once);
            addAddressee.Should().Be(addressee.Id);
        }

        [Test]
        public void Addressee_Service_Add_ShouldHandlerException()
        {
            //Arrange
            var addresseeCmd = ObjectMother.AddresseeCommandToRegister();
            _mockAddresseeRepository.Setup(er => er.Add(It.IsAny<Addressee>())).Throws<Exception>();

            //Action
            Action newAddresseeAcao = () => _addresseeService.Add(addresseeCmd);

            //Assert
            newAddresseeAcao.Should().Throw<Exception>();
            _mockAddresseeRepository.Verify(er => er.Add(It.IsAny<Addressee>()), Times.Once);
        }

        #endregion

        #region Update

        [Test]
        public void Addressee_Service_Update_Sucessfully()
        {
            //Arrange
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            var addresseeCmd = ObjectMother.AddresseeCommandToUpdate();
            var IsUpdate = true;
            _mockAddresseeRepository.Setup(e => e.GetById(addresseeCmd.Id)).Returns(addressee);
            _mockAddresseeRepository.Setup(er => er.Update(addressee)).Returns(IsUpdate);

            //Action
            var updateAddressee = _addresseeService.Update(addresseeCmd);

            //Assert
            _mockAddresseeRepository.Verify(e => e.GetById(addresseeCmd.Id), Times.Once);
            _mockAddresseeRepository.Verify(er => er.Update(addressee), Times.Once);
            updateAddressee.Should().BeTrue();
        }
        [Test]
        public void Addressee_Service_Update_ShouldHandlerNotFoundException()
        {
            //Arrange
            var addresseeCmd = ObjectMother.AddresseeCommandToUpdate();
            _mockAddresseeRepository.Setup(e => e.GetById(addresseeCmd.Id)).Returns((Addressee)null);

            //Action
            Action addresseeAction = () => _addresseeService.Update(addresseeCmd);

            //Assert
            addresseeAction.Should().Throw<NotFoundException>();
            _mockAddresseeRepository.Verify(e => e.GetById(addresseeCmd.Id), Times.Once);
            _mockAddresseeRepository.Verify(e => e.Update(It.IsAny<Addressee>()), Times.Never);
        }

        #endregion

        #region Remove

        [Test]
        public void Addressee_Service_Remove_Sucessfully()
        {
            //Arrange
            var addresseeCmd = ObjectMother.AddresseeCommandToRemove();
            var mockFoiRemovido = true;
            _mockAddresseeRepository.Setup(e => e.Remove(addresseeCmd.AddresseesId.First())).Returns(mockFoiRemovido);

            //Action
            var removed = _addresseeService.Remove(addresseeCmd);

            //Assert
            _mockAddresseeRepository.Verify(e => e.Remove(addresseeCmd.AddresseesId.First()), Times.Once);
            removed.Should().BeTrue();
        }

        [Test]
        public void Addressee_Service_Remove_ShouldHandlerNotFoundException()
        {
            //Arrange
            var addresseeCmd = ObjectMother.AddresseeCommandToRemove();
            _mockAddresseeRepository.Setup(e => e.Remove(addresseeCmd.AddresseesId.First())).Throws<NotFoundException>();

            //Action
            Action AddresseeAcao = () => _addresseeService.Remove(addresseeCmd);

            //Assert
            AddresseeAcao.Should().Throw<NotFoundException>();
            _mockAddresseeRepository.Verify(e => e.Remove(addresseeCmd.AddresseesId.First()), Times.Once);
        }

        #endregion

        #region Get

        [Test]
        public void Addressee_Service_GetById_Sucessfully()
        {
            //Arrange
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            _mockAddresseeRepository.Setup(er => er.GetById(addressee.Id)).Returns(addressee);

            //Action
            var pegarAddressee = _addresseeService.GetById(addressee.Id);

            //Assert
            _mockAddresseeRepository.Verify(er => er.GetById(addressee.Id), Times.Once);
            pegarAddressee.Should().NotBeNull();
            pegarAddressee.Id.Should().Be(addressee.Id);
        }

        [Test]
        public void Addressee_Service_GetById_DeveTratarNotFoundException()
        {
            //Arrange
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            var excecao = new NotFoundException();
            _mockAddresseeRepository.Setup(e => e.GetById(addressee.Id)).Throws(excecao);

            //Action
            Action AddresseeAcao = () => _addresseeService.GetById(addressee.Id);

            //Assert
            AddresseeAcao.Should().Throw<NotFoundException>();
            _mockAddresseeRepository.Verify(e => e.GetById(addressee.Id), Times.Once);
        }

        [Test]
        public void Addressee_Service_GetAll_Sucessfully()
        {
            //Arrange
            var addressee = ObjectMother.AddresseeValidWithIdWithAddress();
            var mockValueRepository = new List<Addressee>() { addressee }.AsQueryable();
            _mockAddresseeRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Action
            var AddresseesResultado = _addresseeService.GetAll();

            //Assert
            _mockAddresseeRepository.Verify(er => er.GetAll(), Times.Once);
            AddresseesResultado.Should().NotBeNull();
            AddresseesResultado.First().Should().Be(addressee);
            AddresseesResultado.Count().Should().Be(mockValueRepository.Count());
        }

        #endregion
    }
}
