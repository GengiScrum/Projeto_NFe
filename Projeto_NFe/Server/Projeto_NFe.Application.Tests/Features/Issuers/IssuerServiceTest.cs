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

        [Test]
        public void Issuer_Service_Add_Sucessfully()
        {
            //Cenário 
            var issuer = ObjectMother.IssuerValidWithoutIdAndWithAddress();
            var issuerCmd = ObjectMother.IssuerCommandToRegister();
            _mockIssuerRepository.Setup(er => er.Add(It.IsAny<Issuer>())).Returns(issuer);

            //Ação
            var addIssuer = _issuerService.Add(issuerCmd);

            //Verificar
            _mockIssuerRepository.Verify(er => er.Add(It.IsAny<Issuer>()), Times.Once);
            addIssuer.Should().Be(issuer.Id);
        }

        [Test]
        public void Issuer_Service_Add_DeveSerTratamentoExcecao()
        {
            //Cenário
            var issuerCmd = ObjectMother.IssuerCommandToRegister();
            _mockIssuerRepository.Setup(er => er.Add(It.IsAny<Issuer>())).Throws<Exception>();

            //Ação
            Action newIssuerAcao = () => _issuerService.Add(issuerCmd);

            //Verificar
            newIssuerAcao.Should().Throw<Exception>();
            _mockIssuerRepository.Verify(er => er.Add(It.IsAny<Issuer>()), Times.Once);
        }
        
        [Test]
        public void Issuer_Service_Update_Sucessfully()
        {
            //Cenário
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var issuerCmd = ObjectMother.IssuerCommandToUpdate();
            var eAtualizado = true;
            _mockIssuerRepository.Setup(e => e.GetById(issuerCmd.Id)).Returns(issuer);
            _mockIssuerRepository.Setup(er => er.Update(issuer)).Returns(eAtualizado);

            //Ação
            var updateIssuer = _issuerService.Update(issuerCmd);

            //Verificar
            _mockIssuerRepository.Verify(e => e.GetById(issuerCmd.Id), Times.Once);
            _mockIssuerRepository.Verify(er => er.Update(issuer), Times.Once);
            updateIssuer.Should().BeTrue();
        }

        [Test]
        public void Issuer_Service_Update_DeveTratarNaoEncontrado()
        {
            //Cenário
            var issuerCmd = ObjectMother.IssuerCommandToUpdate();
            _mockIssuerRepository.Setup(e => e.GetById(issuerCmd.Id)).Returns((Issuer)null);

            //Ação
            Action issuerAcao = () => _issuerService.Update(issuerCmd);

            //Verificar
            issuerAcao.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.GetById(issuerCmd.Id), Times.Once);
            _mockIssuerRepository.Verify(e => e.Update(It.IsAny<Issuer>()), Times.Never);
        }

        [Test]
        public void Issuer_Service_Remove_Sucessfully()
        {
            //Cenário
            var issuerCmd = ObjectMother.IssuerCommandToRemove();
            var mockFoiRemovido = true;
            _mockIssuerRepository.Setup(e => e.Remove(issuerCmd.IssuersId.First())).Returns(mockFoiRemovido);

            //Ação
            var eProductRemovido = _issuerService.Remove(issuerCmd );

            //Verificar
            _mockIssuerRepository.Verify(e => e.Remove(issuerCmd.IssuersId.First()), Times.Once);
            eProductRemovido.Should().BeTrue();
        }

        [Test]
        public void Issuer_Service_Remove_DeveTratarNaoEncontrado()
        {
            //Cenário
            var issuerCmd = ObjectMother.IssuerCommandToRemove();
            _mockIssuerRepository.Setup(e => e.Remove(issuerCmd.IssuersId.First())).Throws<NotFoundException>();

            //Ação
            Action issuerAcao = () => _issuerService.Remove(issuerCmd);

            //Verificar
            issuerAcao.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.Remove(issuerCmd.IssuersId.First()), Times.Once);
        }

        [Test]
        public void Issuer_Service_GetById_Sucessfully()
        {
            //Cenário
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            _mockIssuerRepository.Setup(er => er.GetById(issuer.Id)).Returns(issuer);

            //Ação
            var pegarIssuer = _issuerService.GetById(issuer.Id);

            //Verificar
            _mockIssuerRepository.Verify(er => er.GetById(issuer.Id), Times.Once);
            pegarIssuer.Should().NotBeNull();
            pegarIssuer.Id.Should().Be(issuer.Id);
        }

        [Test]
        public void Issuer_Service_GetById_DeveTratarNotFoundException()
        {
            //Cenário
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var excecao = new NotFoundException();
            _mockIssuerRepository.Setup(e => e.GetById(issuer.Id)).Throws(excecao);

            //Ação
            Action issuerAcao = () => _issuerService.GetById(issuer.Id);

            //Verificar
            issuerAcao.Should().Throw<NotFoundException>();
            _mockIssuerRepository.Verify(e => e.GetById(issuer.Id), Times.Once);
        }

        [Test]
        public void Issuer_Service_GetAll_Sucessfully()
        {
            //Cenário
            var issuer = ObjectMother.IssuerValidWithIdAndWithAddress();
            var mockValueRepository = new List<Issuer>() { issuer }.AsQueryable();
            _mockIssuerRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Ação
            var issuersResultado = _issuerService.GetAll();

            //Verificar
            _mockIssuerRepository.Verify(er => er.GetAll(), Times.Once);
            issuersResultado.Should().NotBeNull();
            issuersResultado.First().Should().Be(issuer);
            issuersResultado.Count().Should().Be(mockValueRepository.Count());
        }
    }
}
