using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Tests.Features.Invoices
{
    [TestFixture]
    public class InvoicePDFRepositoryTests
    {
        Invoice _invoice;
        InvoicePDFRepository _invoiceRepository;

        [SetUp]
        public void Initialize()
        {
            _invoice = new Invoice();
            _invoiceRepository = new InvoicePDFRepository();
        }

        [Test]
        public void Invoice_PDFRepository_Export_ShippingCompanyPessoaJuridica_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithShippingCompanyLegalPerson();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IssuedInvoice.pdf");

            //Ação
            _invoiceRepository.Export(_invoice, path);

            //Verificar
            File.Exists(path).Should().BeTrue();
        }

        [Test]
        public void Invoice_PDFRepository_Export_ShippingCompanyPessoaFisica_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithShippingCompanyPerson();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IssuedInvoice.pdf");

            //Ação
            _invoiceRepository.Export(_invoice, path);

            //Verificar
            File.Exists(path).Should().BeTrue();
        }

        [Test]
        public void Invoice_PDFRepository_Export_WithoutShippingCompanyWithAddresseePessoaFisica_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithoutShippingCompanyWithAddresseePerson();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IssuedInvoice.pdf");

            //Ação
            _invoiceRepository.Export(_invoice, path);

            //Verificar
            File.Exists(path).Should().BeTrue();
        }

        [Test]
        public void Invoice_PDFRepository_Export_WithoutShippingCompanyWithAddresseePessoaJuridica_Sucessfully()
        {
            //Cenário
            _invoice = ObjectMother.IssuedInvoiceValidWithoutShippingCompanyWithAddresseeLegalPerson();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IssuedInvoice.pdf");

            //Ação
            _invoiceRepository.Export(_invoice, path);

            //Verificar
            File.Exists(path).Should().BeTrue();
        }
    }
}
