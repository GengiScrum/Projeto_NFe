using FluentAssertions;
using Moq;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Exceptions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Application.Tests.Initializer;
using Projeto_NFe.Application.Features.Issuers;
using Projeto_NFe.Application.Features.Issuers.Queries;

namespace Projeto_NFe.Application.Tests.Features.Issuers
{
    [TestFixture]
    public class IssuerServiceTest : TestServiceBase
    {
        IIssuerService _issuerService;
        Mock<IIssuerRepository> _mockIssuerRepository;

        [SetUp]
        public void Initialize()
        {
            _mockIssuerRepository = new Mock<IIssuerRepository>();
            _issuerService = new IssuerService(_mockIssuerRepository.Object);
        }

        #region Add

        [Test]
        public void Issuer_Service_Add_Sucessfully()
        {
            //Arrange 
            var issuer = ObjectMother.IssuerValidWithoutIdAndWithAddress();
            var issuerCmd = ObjectMother.IssuerCommandToRegister();
            _mockIssuerRepository.Setup(er => er.Add(It.IsAny<Issuer>())).Returns(issuer);

            //Action
            var addIssuer = _issuerService.Add(issuerCmd);

            //Verificar
            _mockIssuerRepository.Verify(er => er.Add(It.IsAny<Issuer>()), Times.Once);
            addIssuer.Should().Be(issuer.Id);
        }

        [Test]
        public void Issuer_Service_Add_ShouldThrowException()
        {
            //Arrange
            var issuerCmd = ObjectMother.IssuerCommandToRegister();
            _mockIssuerRepository.Setup(er => er.Add(It.IsAny<Issuer>())).Throws<Exception>();

            //Action
            Action act = () => _issuerService.Add(issuerCmd);

            //Verificar
            act.Should().Throw<Exception>();
            _mockIssuerRepository.Verify(er => er.Add(It.IsAny<Issuer>()), Times.Once);
        }

        #endregion

        #region Update
        [Test]
        public void Issuer_Service_Update_Sucessfully()
        {
            //Arrange
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var issuerCmd = ObjectMother.IssuerCommandToUpdate();
            var updated = true;
            _mockIssuerRepository.Setup(e => e.GetById(issuerCmd.Id)).Returns(issuer);
            _mockIssuerRepository.Setup(er => er.Update(issuer)).Returns(updated);

            //Action
            var updatedIssuer = _issuerService.Update(issuerCmd);

            //Verificar
            _mockIssuerRepository.Verify(e => e.GetById(issuerCmd.Id), Times.Once);
            _mockIssuerRepository.Verify(er => er.Update(issuer), Times.Once);
            updatedIssuer.Should().BeTrue();
        }

        [Test]
        public void Issuer_Service_Update_ShouldThrowNotFoundException()
        {
            //Arrange
            var issuerCmd = ObjectMother.IssuerCommandToUpdate();
            _mockIssuerRepository.Setup(e => e.GetById(issuerCmd.Id)).Returns((Issuer)null);

            //Action
            Action act = () => _issuerService.Update(issuerCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.GetById(issuerCmd.Id), Times.Once);
            _mockIssuerRepository.Verify(e => e.Update(It.IsAny<Issuer>()), Times.Never);
        }

        #endregion

        #region Remove
        [Test]
        public void Issuer_Service_Remove_Sucessfully()
        {
            //Arrange
            var issuerCmd = ObjectMother.IssuerCommandToRemove();
            var mockWasRemoved = true;
            _mockIssuerRepository.Setup(e => e.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var eProductRemovido = _issuerService.Remove(issuerCmd );

            //Verificar
            _mockIssuerRepository.Verify(e => e.Remove(It.IsAny<int>()), Times.Once);
            eProductRemovido.Should().BeTrue();
        }

        [Test]
        public void Issuer_Service_Remove_ReturnFalse()
        {
            //Arrange
            var issuerCmd = ObjectMother.IssuerCommandToRemove();
            var mockWasRemoved = false;
            _mockIssuerRepository.Setup(e => e.Remove(It.IsAny<int>())).Returns(mockWasRemoved);

            //Action
            var removed = _issuerService.Remove(issuerCmd);

            //Assert
            _mockIssuerRepository.Verify(e => e.Remove(It.IsAny<int>()), Times.Once);
            removed.Should().BeFalse();
        }

        [Test]
        public void Issuer_Service_Remove_ShouldThrowNotFoundException()
        {
            //Arrange
            var issuerCmd = ObjectMother.IssuerCommandToRemove();
            _mockIssuerRepository.Setup(e => e.Remove(It.IsAny<int>())).Throws<NotFoundException>();

            //Action
            Action act = () => _issuerService.Remove(issuerCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.Remove(It.IsAny<int>()), Times.Once);
        }
        #endregion

        #region Get
        [Test]
        public void Issuer_Service_GetById_Sucessfully()
        {
            //Arrange
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            _mockIssuerRepository.Setup(er => er.GetById(issuer.Id)).Returns(issuer);

            //Action
            var getIssuer = _issuerService.GetById(issuer.Id);

            //Verificar
            _mockIssuerRepository.Verify(er => er.GetById(issuer.Id), Times.Once);
            getIssuer.Should().NotBeNull();
            getIssuer.Id.Should().Be(issuer.Id);
        }

        [Test]
        public void Issuer_Service_GetById_ShouldThrowNotFoundException()
        {
            //Arrange
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var exception = new NotFoundException();
            _mockIssuerRepository.Setup(e => e.GetById(issuer.Id)).Throws(exception);

            //Action
            Action act = () => _issuerService.GetById(issuer.Id);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.GetById(issuer.Id), Times.Once);
        }

        [Test]
        public void Issuer_Service_GetAll_Sucessfully()
        {
            //Arrange
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var mockValueRepository = new List<Issuer>() { issuer }.AsQueryable();
            _mockIssuerRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Action
            var issuers = _issuerService.GetAll();

            //Verificar
            _mockIssuerRepository.Verify(er => er.GetAll(), Times.Once);
            issuers.Should().NotBeNull();
            issuers.First().Should().Be(issuer);
            issuers.Count().Should().Be(mockValueRepository.Count());
        }

        [Test]
        public void Issuer_Service_GetAllWithQuantity_Sucessfully()
        {
            //Arrange
            int quantity = 2;
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var issuerQuery = new Mock<IssuerQuery>();
            issuerQuery.Object.Quantity = quantity;
            var mockValueRepository = new List<Issuer>() { issuer, issuer }.AsQueryable();
            _mockIssuerRepository.Setup(er => er.GetAll(It.IsAny<int>())).Returns(mockValueRepository);

            //Action
            var issuers = _issuerService.GetAll(issuerQuery.Object);

            //Assert
            _mockIssuerRepository.Verify(er => er.GetAll(It.IsAny<int>()), Times.Once);
            issuers.Should().NotBeNull();
            issuers.First().Should().Be(issuer);
            issuers.Count().Should().Be(mockValueRepository.Count());
        }

        #endregion
    }
}
