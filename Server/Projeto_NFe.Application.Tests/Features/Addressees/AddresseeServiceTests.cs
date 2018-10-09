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

namespace Projeto_NFe.Application.Tests.Features.Addressees
{
    [TestFixture]
    public class AddresseeServiceTests
    {
        Addressee _addressee;
        Addressee _AddresseeEsperada;
        AddresseeService _service;
        Mock<IAddresseeRepository> _repository;
        Address _address;

        [SetUp]
        public void Initialize()
        {
            _addressee = new Addressee();
            _AddresseeEsperada = new Addressee();
            _repository = new Mock<IAddresseeRepository>();
            _service = new AddresseeService(_repository.Object);
            _address = new Address();
        }
        #region Add Pessoa Fisica
        [Test]
        public void Addressee_Service_Add_PessoaFisica_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaFisicaValida(_address);
            _repository.Setup(r => r.Add(_addressee)).Returns(_addressee);

            //Ação
            _AddresseeEsperada = _service.Add(_addressee);

            //Verificar
            _AddresseeEsperada.Should().NotBeNull();
            _AddresseeEsperada.Id.Should().Be(_addressee.Id);
            _repository.Verify(r => r.Add(_addressee));
        }
        #endregion

        #region Add Pessoa Juridica
        [Test]
        public void Addressee_Service_Add_PessoaJuridica_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_address);
            _repository.Setup(r => r.Add(_addressee)).Returns(_addressee);

            //Ação
            _AddresseeEsperada = _service.Add(_addressee);

            //Verificar
            _AddresseeEsperada.Should().NotBeNull();
            _AddresseeEsperada.Id.Should().Be(_addressee.Id);
            _repository.Verify(r => r.Add(_addressee));
        }
        #endregion

        [Test]
        public void Addressee_Service_Update_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaFisicaWithIdInvalid(_address);

            //Ação
            Action act = () => _service.Update(_addressee);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }

        #region Update Pessoa Fisica
        [Test]
        public void Addressee_Service_Update_PessoaFisica_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaFisicaValida(_address);
            _repository.Setup(r => r.Update(_addressee)).Returns(true);

            //Ação
            _AddresseeEsperada = _service.Update(_addressee);

            ////Verificar
            //_AddresseeEsperada.Should().NotBeNull();
            //_AddresseeEsperada.Id.Should().Be(_addressee.Id);
            //_repository.Verify(r => r.Update(_addressee));
        }               
        #endregion

        #region Update Pessoa Juridica
        [Test]
        public void Addressee_Service_Update_PessoaJuridica_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_address);
            _repository.Setup(r => r.Update(_addressee)).Returns(true);

            //Ação
            _AddresseeEsperada = _service.Update(_addressee);

            ////Verificar
            //_AddresseeEsperada.Should().NotBeNull();
            //_AddresseeEsperada.Id.Should().Be(_addressee.Id);
            //_repository.Verify(r => r.Update(_addressee));
        }        
        #endregion

        [Test]
        public void Addressee_Service_GetById_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_address);
            _repository.Setup(r => r.GetById(_addressee.Id)).Returns(_addressee);

            //Ação
            _AddresseeEsperada = _service.GetById(_addressee);

            //Verificar
            _AddresseeEsperada.Should().NotBeNull();
            _AddresseeEsperada.Id.Should().Be(_addressee.Id);
            _repository.Verify(r => r.GetById(_addressee.Id));
        }

        [Test]
        public void Addressee_Service_GetById_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaWithIdInvalid(_address);

            //Ação
            Action act = () => _service.GetById(_addressee);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Addressee_Service_GetAll_Sucessfully()
        {
            //Cenario
            var listaAddressee = new List<Addressee>();
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_address);
            listaAddressee.Add(_addressee);
            _repository.Setup(r => r.GetAll()).Returns(listaAddressee as IQueryable<Addressee>);

            //Ação
            var listaEsperada = _service.GetAll();

            //listaEsperada.Should().NotBeNull();
            //listaEsperada.Last().Id.Should().Be(_addressee.Id);
            //_repository.Verify(r => r.GetAll());
        }

        [Test]
        public void Addressee_Service_Remove_Sucessfully()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_address);
            _repository.Setup(r => r.Remove(_addressee.Id));

            //Ação
            _service.Remove(_addressee);
            _AddresseeEsperada = _service.GetById(_addressee);

            //Verificar
            _AddresseeEsperada.Should().BeNull();
            _repository.Verify(r => r.Remove(_addressee.Id));
        }

        [Test]
        public void Addressee_Service_Remove_ShouldThrowIdentifierUndefinedException()
        {
            //Cenario
            _address = ObjectMother.AddressValid();
            _addressee = ObjectMother.AddresseePessoaJuridicaWithIdInvalid(_address);

            //Ação
            Action act = () => _service.Remove(_addressee);

            //Verificar
            act.Should().Throw<IdentifierUndefinedException>();
            _repository.VerifyNoOtherCalls();
        }
    }
}
