using Effort.Provider;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Tests.Initializer
{
    [TestFixture]
    public class EffortTestBase
    {
        [OneTimeSetUp]
        public void InitializarUmaVez()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        [SetUp]
        public void Inicializa()
        {
            EffortProviderFactory.ResetDb();
        }
    }
}
