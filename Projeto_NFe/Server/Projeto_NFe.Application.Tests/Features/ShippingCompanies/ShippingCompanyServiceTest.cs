using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Tests.Initializer;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using Projeto_NFe.Application.Features.ShippingCompanies;

namespace Projeto_NFe.Application.Tests.Features.ShippingCompanies
{
    [TestFixture]
    public class ShippingCompanyServiceTest : TestServiceBase
    {
        IShippingCompanyService _shippingCompanyService;
        Mock<IShippingCompanyRepository> _mockShippingCompanyRepository;

        [SetUp]
        public void Initialize()
        {
            _mockShippingCompanyRepository = new Mock<IShippingCompanyRepository>();
            _shippingCompanyService = new ShippingCompanyService(_mockShippingCompanyRepository.Object);
        }

        #region Add

        [Test]
        public void ShippingCompany_Service_Add_Sucessfully()
        {
            //Cenário 
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRegister();
            _mockShippingCompanyRepository.Setup(er => er.Add(It.IsAny<ShippingCompany>())).Returns(shippingCompany);

            //Ação
            var addShippingCompany = _shippingCompanyService.Add(shippingCompanyCmd);

            //Verificar
            _mockShippingCompanyRepository.Verify(er => er.Add(It.IsAny<ShippingCompany>()), Times.Once);
            addShippingCompany.Should().Be(shippingCompany.Id);
        }

        [Test]
        public void ShippingCompany_Service_Add_ShouldThrowException()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRegister();
            _mockShippingCompanyRepository.Setup(er => er.Add(It.IsAny<ShippingCompany>())).Throws<Exception>();

            //Ação
            Action act = () => _shippingCompanyService.Add(shippingCompanyCmd);

            //Verificar
            act.Should().Throw<Exception>();
            _mockShippingCompanyRepository.Verify(er => er.Add(It.IsAny<ShippingCompany>()), Times.Once);
        }

        #endregion

        #region Update

        [Test]
        public void ShippingCompany_Service_Update_Sucessfully()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToUpdate();
            var updated = true;
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompanyCmd.Id)).Returns(shippingCompany);
            _mockShippingCompanyRepository.Setup(er => er.Update(shippingCompany)).Returns(updated);

            //Ação
            var updatedShippingCompany = _shippingCompanyService.Update(shippingCompanyCmd);

            //Verificar
            _mockShippingCompanyRepository.Verify(e => e.GetById(shippingCompanyCmd.Id), Times.Once);
            _mockShippingCompanyRepository.Verify(er => er.Update(shippingCompany), Times.Once);
            updatedShippingCompany.Should().BeTrue();
        }

        [Test]
        public void ShippingCompany_Service_Update_ShouldThrowNotFoundException()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToUpdate();
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompanyCmd.Id)).Returns((ShippingCompany)null);

            //Ação
            Action act = () => _shippingCompanyService.Update(shippingCompanyCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockShippingCompanyRepository.Verify(e => e.GetById(shippingCompanyCmd.Id), Times.Once);
            _mockShippingCompanyRepository.Verify(e => e.Update(It.IsAny<ShippingCompany>()), Times.Never);
        }

        #endregion

        #region Remove

        [Test]
        public void ShippingCompany_Service_Remove_Sucessfully()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRemove();
            var mockWasRemoved = true;
            _mockShippingCompanyRepository.Setup(e => e.Remove(shippingCompanyCmd.Ids.First())).Returns(mockWasRemoved);

            //Ação
            var productRemoved = _shippingCompanyService.Remove(shippingCompanyCmd);

            //Verificar
            _mockShippingCompanyRepository.Verify(e => e.Remove(shippingCompanyCmd.Ids.First()), Times.Once);
            productRemoved.Should().BeTrue();
        }

        [Test]
        public void ShippingCompany_Service_Remove_ShouldThrowNotFounException()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRemove();
            _mockShippingCompanyRepository.Setup(e => e.Remove(shippingCompanyCmd.Ids.First())).Throws<NotFoundException>();

            //Ação
            Action act = () => _shippingCompanyService.Remove(shippingCompanyCmd);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockShippingCompanyRepository.Verify(e => e.Remove(shippingCompanyCmd.Ids.First()), Times.Once);
        }

        #endregion

        #region Get

        [Test]
        public void ShippingCompany_Service_GetById_Sucessfully()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            _mockShippingCompanyRepository.Setup(er => er.GetById(shippingCompany.Id)).Returns(shippingCompany);

            //Ação
            var getShippingCompany = _shippingCompanyService.GetById(shippingCompany.Id);

            //Verificar
            _mockShippingCompanyRepository.Verify(er => er.GetById(shippingCompany.Id), Times.Once);
            getShippingCompany.Should().NotBeNull();
            getShippingCompany.Id.Should().Be(shippingCompany.Id);
        }

        [Test]
        public void ShippingCompany_Service_GetById_ShouldThrowNotFoundException()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var exception = new NotFoundException();
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompany.Id)).Throws(exception);

            //Ação
            Action act = () => _shippingCompanyService.GetById(shippingCompany.Id);

            //Verificar
            act.Should().Throw<NotFoundException>();
            _mockShippingCompanyRepository.Verify(e => e.GetById(shippingCompany.Id), Times.Once);
        }

        [Test]
        public void ShippingCompany_Service_GetAll_Sucessfully()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var mockValueRepository = new List<ShippingCompany>() { shippingCompany }.AsQueryable();
            _mockShippingCompanyRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Ação
            var shippingCompanysResultado = _shippingCompanyService.GetAll();

            //Verificar
            _mockShippingCompanyRepository.Verify(er => er.GetAll(), Times.Once);
            shippingCompanysResultado.Should().NotBeNull();
            shippingCompanysResultado.First().Should().Be(shippingCompany);
            shippingCompanysResultado.Count().Should().Be(mockValueRepository.Count());
        }

        #endregion
    }
}
