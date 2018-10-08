using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.IssuedInvoices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.XML.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoiceXMLRepositoryTests
    {
        Invoice _invoice;
        IssuedInvoiceXMLRepository _repository;
        string _file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testeXml.xml");

        [SetUp]
        public void Initialize()
        {
            _invoice = new Invoice();
            _repository = new IssuedInvoiceXMLRepository();
        }

        [Test]
        public void Invoice_XMLRepository_Export_Sucessfully()
        {
            //cenario
            _invoice = ObjectMother.IssuedInvoiceFullToExport();

            //ação
            _repository.Export(_invoice, _file);

            //verificacao
            File.Exists(_file).Should().BeTrue();
        }
    }
}
