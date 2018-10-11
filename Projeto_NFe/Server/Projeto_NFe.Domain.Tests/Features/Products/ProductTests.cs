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
        
        [TearDown]
        public void Finalize()
        {
            _product = null;
        }
    }
}
