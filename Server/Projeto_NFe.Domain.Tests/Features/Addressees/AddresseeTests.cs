using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Addresses;
using Projeto_NFe.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Addressees
{
    [TestFixture]
    public class AddresseeTests
    {
        Addressee _addressee;
        Mock<Address> _mockAddress;

        [SetUp]
        public void Initialize()
        {
            _addressee = new Addressee();
            _mockAddress = new Mock<Address>();
        }

        [Test]
        public void Addressee_Domain_Validate_PessoaFisica_Sucessfully()
        {
            //cenário            
            _addressee = ObjectMother.AddresseePessoaFisicaValida(_mockAddress.Object);

            //ação
            Action act = () =>  _addressee.Validate();

            //verificação
            act.Should().NotThrow();
            _addressee.Address.Should().NotBeNull();
            _addressee.PersonType.Should().Be(EnumPersonType.PessoaFisica);
            _addressee.CorporateName.Should().BeNullOrEmpty();
            _addressee.Cnpj.Should().BeNullOrEmpty();
            _addressee.StateRegistration.Should().BeNullOrEmpty();
        }        

        [Test]
        public void Addressee_Domain_Validate_PessoaJuridica_Sucessfully()
        {
            //cenário            
            _addressee = ObjectMother.AddresseePessoaJuridicaValida(_mockAddress.Object);

            //ação
            Action act = () => _addressee.Validate();

            //verificação
            act.Should().NotThrow();
            _addressee.Address.Should().NotBeNull();
            _addressee.PersonType.Should().Be(EnumPersonType.PessoaJuridica);
            _addressee.Cpf.Should().BeNullOrEmpty();
        }        
    }
}
