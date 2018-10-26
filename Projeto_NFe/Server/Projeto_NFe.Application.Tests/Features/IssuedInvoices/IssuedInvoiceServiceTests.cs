using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Features.IssuedInvoices;
using Projeto_NFe.Application.Features.IssuedInvoices.Commands;
using Projeto_NFe.Common.Tests;
using Projeto_NFe.Domain.Exceptions;
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
        Mock<IIssuedInvoiceRepository> _mockIssuedInvoiceRepository;
        Mock<IInvoiceRepository> _mockInvoiceRepository;
        Mock<IIssuedInvoiceXMLRepository> _xmlRepository;
        Mock<IInvoicePDFRepository> _pdfRepository;

        [SetUp]
        public void Initialize()
        {
            _invoice = new Invoice();
            _xmlRepository = new Mock<IIssuedInvoiceXMLRepository>();
            _pdfRepository = new Mock<IInvoicePDFRepository>();
            _mockIssuedInvoiceRepository = new Mock<IIssuedInvoiceRepository>();
            _mockInvoiceRepository = new Mock<IInvoiceRepository>();
            _service = new IssuedInvoiceService(_xmlRepository.Object, _pdfRepository.Object, _mockIssuedInvoiceRepository.Object, _mockInvoiceRepository.Object);
        }

        [Test]
        public void IssuedInvoice_XMLRepository_ExportToXML_Sucessfully()
        {
            var file = "Caminho";
            _invoice = ObjectMother.IssuedInvoiceFullToExport();
            _xmlRepository.Setup(rXML => rXML.Export(_invoice, file));

            _service.ExportToXML(_invoice, file);

            _xmlRepository.Verify(xmlr => xmlr.Export(_invoice, file));
        }

        [Test]
        public void IssuedInvoice_PDFRepository_ExportToPDF_Sucessfully()
        {
            var file = "Caminho";
            _invoice = ObjectMother.IssuedInvoiceFullToExport();
            _pdfRepository.Setup(rPDF => rPDF.Export(_invoice, file));

            _service.ExportToPDF(_invoice, file);

            _pdfRepository.Verify(pdfr => pdfr.Export(_invoice, file));
        }

        [Test]
        public void IssuedInvoice_Service_GetById_Sucessfully()
        {
            //Arrange
            var issuedInvoice = ObjectMother.IssuedInvoiceValidWithId();
            _mockIssuedInvoiceRepository.Setup(er => er.GetById(issuedInvoice.Id)).Returns(issuedInvoice);

            //Action
            var pegarIssuedInvoice = _service.GetById(issuedInvoice.Id);

            //Assert
            _mockIssuedInvoiceRepository.Verify(er => er.GetById(issuedInvoice.Id), Times.Once);
            pegarIssuedInvoice.Should().NotBeNull();
            pegarIssuedInvoice.Id.Should().Be(issuedInvoice.Id);
        }

        [Test]
        public void IssuedInvoice_Service_GetAll_Sucessfully()
        {
            //Arrange
            var issuedInvoice = ObjectMother.IssuedInvoiceValidWithId();
            var mockValueRepository = new List<Invoice>() { issuedInvoice }.AsQueryable();
            _mockIssuedInvoiceRepository.Setup(er => er.GetAll()).Returns(mockValueRepository);

            //Action
            var issuedInvoices = _service.GetAll();

            //Assert
            _mockIssuedInvoiceRepository.Verify(er => er.GetAll(), Times.Once);
            issuedInvoices.Should().NotBeNull();
            issuedInvoices.First().Should().Be(issuedInvoice);
            issuedInvoices.Count().Should().Be(mockValueRepository.Count());
        }
    }
}
