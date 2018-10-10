using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.IssuedInvoices;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.IssuedInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Tests.Features.IssuedInvoices
{
    public class IssuedInvoiceServiceTests
    {
        Invoice _invoice;
        IIssuedInvoiceService _service;
        Mock<IIssuedInvoiceXMLRepository> _repositoryXML;
        Mock<IInvoicePDFRepository> _repostorioPDF;

        [SetUp]
        public void Initialize()
        {
            _invoice = new Invoice();
            _repositoryXML = new Mock<IIssuedInvoiceXMLRepository>();
            _repostorioPDF = new Mock<IInvoicePDFRepository>();
            _service = new IssuedInvoiceService(_repositoryXML.Object, _repostorioPDF.Object);
        }

        [Test]
        public void IssuedInvoice_XMLRepository_ExportToXML_Sucessfully()
        {
            var file = "Caminho";
            _invoice = ObjectMother.IssuedInvoiceFullToExport();
            _repositoryXML.Setup(rXML => rXML.Export(_invoice, file));

            _service.ExportToXML(_invoice, file);

            _repositoryXML.Verify(rXML => rXML.Export(_invoice, file));
        }

        [Test]
        public void IssuedInvoice_PDFRepository_ExportToPDF_Sucessfully()
        {
            var file = "Caminho";
            _invoice = ObjectMother.IssuedInvoiceFullToExport();
            _repostorioPDF.Setup(rPDF => rPDF.Export(_invoice, file));

            _service.ExportToPDF(_invoice, file);

            _repostorioPDF.Verify(rPDF => rPDF.Export(_invoice, file));
        }
    }
}
