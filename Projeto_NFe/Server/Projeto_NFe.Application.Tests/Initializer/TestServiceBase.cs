using NUnit.Framework;
using Projeto_NFe.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Initializer
{
    [TestFixture]
    public class TestServiceBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            AutoMapperInitializer.Reset();
            AutoMapperInitializer.Initialize();
        }
    }
}
