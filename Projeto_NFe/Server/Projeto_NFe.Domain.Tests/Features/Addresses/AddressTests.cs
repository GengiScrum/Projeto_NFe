using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Addresses
{
    [TestFixture]
    public class AddressTests
    {
        Address _address;

        [SetUp]
        public void Initialize()
        {
            _address = new Address();
        }
        
        [Test]
        public void Address_Domain_ValidateStreetName_Sucessfully()
        {
            //Cenário
            _address = ObjectMother.AddressValid();

            //Ação
            Action acao = () => _address.Validate();

            //Verificar
            acao.Should().NotThrow();
        }
        
        [TearDown]
        public void Finalize()
        {
            _address = null;
        }
    }
}
