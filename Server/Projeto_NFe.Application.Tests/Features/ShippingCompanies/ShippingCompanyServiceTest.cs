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
        public void ShippingCompany_Service_Add_DeveSerTratamentoExcecao()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRegister();
            _mockShippingCompanyRepository.Setup(er => er.Add(It.IsAny<ShippingCompany>())).Throws<Exception>();

            //Ação
            Action newShippingCompanyAcao = () => _shippingCompanyService.Add(shippingCompanyCmd);

            //Verificar
            newShippingCompanyAcao.Should().Throw<Exception>();
            _mockShippingCompanyRepository.Verify(er => er.Add(It.IsAny<ShippingCompany>()), Times.Once);
        }

        [Test]
        public void ShippingCompany_Service_Update_Sucessfully()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToUpdate();
            var eAtualizado = true;
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompanyCmd.Id)).Returns(shippingCompany);
            _mockShippingCompanyRepository.Setup(er => er.Update(shippingCompany)).Returns(eAtualizado);

            //Ação
            var updateShippingCompany = _shippingCompanyService.Update(shippingCompanyCmd);

            //Verificar
            _mockShippingCompanyRepository.Verify(e => e.GetById(shippingCompanyCmd.Id), Times.Once);
            _mockShippingCompanyRepository.Verify(er => er.Update(shippingCompany), Times.Once);
            updateShippingCompany.Should().BeTrue();
        }

        [Test]
        public void ShippingCompany_Service_Update_DeveTratarNaoEncontrado()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToUpdate();
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompanyCmd.Id)).Returns((ShippingCompany)null);

            //Ação
            Action shippingCompanyAcao = () => _shippingCompanyService.Update(shippingCompanyCmd);

            //Verificar
            shippingCompanyAcao.Should().Throw<NotFoundException>();
            _mockShippingCompanyRepository.Verify(e => e.GetById(shippingCompanyCmd.Id), Times.Once);
            _mockShippingCompanyRepository.Verify(e => e.Update(It.IsAny<ShippingCompany>()), Times.Never);
        }

        [Test]
        public void ShippingCompany_Service_Remove_Sucessfully()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRemove();
            var mockFoiRemovido = true;
            _mockShippingCompanyRepository.Setup(e => e.Remove(shippingCompanyCmd.Ids.First())).Returns(mockFoiRemovido);

            //Ação
            var eProductRemovido = _shippingCompanyService.Remove(shippingCompanyCmd);

            //Verificar
            _mockShippingCompanyRepository.Verify(e => e.Remove(shippingCompanyCmd.Ids.First()), Times.Once);
            eProductRemovido.Should().BeTrue();
        }

        [Test]
        public void ShippingCompany_Service_Remove_DeveTratarNaoEncontrado()
        {
            //Cenário
            var shippingCompanyCmd = ObjectMother.ShippingCompanyCommandToRemove();
            _mockShippingCompanyRepository.Setup(e => e.Remove(shippingCompanyCmd.Ids.First())).Throws<NotFoundException>();

            //Ação
            Action shippingCompanyAcao = () => _shippingCompanyService.Remove(shippingCompanyCmd);

            //Verificar
            shippingCompanyAcao.Should().Throw<NotFoundException>();
            _mockShippingCompanyRepository.Verify(e => e.Remove(shippingCompanyCmd.Ids.First()), Times.Once);
        }

        [Test]
        public void ShippingCompany_Service_GetById_Sucessfully()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            _mockShippingCompanyRepository.Setup(er => er.GetById(shippingCompany.Id)).Returns(shippingCompany);

            //Ação
            var pegarShippingCompany = _shippingCompanyService.GetById(shippingCompany.Id);

            //Verificar
            _mockShippingCompanyRepository.Verify(er => er.GetById(shippingCompany.Id), Times.Once);
            pegarShippingCompany.Should().NotBeNull();
            pegarShippingCompany.Id.Should().Be(shippingCompany.Id);
        }

        [Test]
        public void ShippingCompany_Service_GetById_DeveTratarNotFoundException()
        {
            //Cenário
            var shippingCompany = ObjectMother.ShippingCompanyValidWithIdWithAddress();
            var excecao = new NotFoundException();
            _mockShippingCompanyRepository.Setup(e => e.GetById(shippingCompany.Id)).Throws(excecao);

            //Ação
            Action shippingCompanyAcao = () => _shippingCompanyService.GetById(shippingCompany.Id);

            //Verificar
            shippingCompanyAcao.Should().Throw<NotFoundException>();
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
    }
}
