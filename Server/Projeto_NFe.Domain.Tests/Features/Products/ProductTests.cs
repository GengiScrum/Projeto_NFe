using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductTests
    {
        Product _product;

        [SetUp]
        public void Initialize()
        {
            _product = new Product();
        }

        [Test]
        public void Product_Domain_Validate_Sucessfully()
        {
            //Cenário
            _product = ObjectMother.ProductValidWithoutId();

            //Ação
            Action act = () => _product.Validate();

            //Verificar
            act.Should().NotThrow();
        }
        
        [TearDown]
        public void Finalize()
        {
            _product = null;
        }
    }
}
