using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Features.ProductTaxes
{
    [TestFixture]
    public class ProductTaxTests
    {
        ProductTax _taxProduct;

        [SetUp]
        public void Initialize()
        {
            _taxProduct = new ProductTax();
        }

        [Test]
        public void ProductTax_Domain_CalculateIpi_Sucessfully()
        {
            //Arrange
            _taxProduct = ObjectMother.ProductTaxWithAliquotIcsmAndIpiAliquot();
            double amount = 50;

            //ação
            _taxProduct.CalculateIpi(amount);

            //verificação
            _taxProduct.IpiValue.Should().Be(5);
        }

        [Test]
        public void ProductTax_Domain_CalculateIcms_Sucessfully()
        {
            //Arrange
            _taxProduct = ObjectMother.ProductTaxWithAliquotIcsmAndIpiAliquot();
            double amount = 50;

            //ação
            _taxProduct.CalculateIcms(amount);

            //verificação
            _taxProduct.IcmsValue.Should().Be(2);
        }
    }
}
