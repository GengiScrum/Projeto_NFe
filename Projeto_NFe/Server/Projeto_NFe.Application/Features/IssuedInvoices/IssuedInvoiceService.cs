using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.IssuedInvoices;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using System.Linq;
using Projeto_NFe.Domain.Exceptions;
using Projeto_NFe.Application.Features.IssuedInvoices.Commands;

namespace Projeto_NFe.Application.Features.IssuedInvoices
{
    public class IssuedInvoiceService : IIssuedInvoiceService
    {
        IIssuedInvoiceXMLRepository _repositoryXML;
        IInvoicePDFRepository _repositoryPDF;
        IIssuedInvoiceRepository _issuedInvoiceRepository;
        IInvoiceRepository _invoiceRepository;

        public IssuedInvoiceService(IIssuedInvoiceXMLRepository repositoryXML, IInvoicePDFRepository repositoryPDF, IIssuedInvoiceRepository issuedInvoiceRepository, IInvoiceRepository invoiceRepository)
        {
            _repositoryXML = repositoryXML;
            _repositoryPDF = repositoryPDF;
            _issuedInvoiceRepository = issuedInvoiceRepository;
            _invoiceRepository = invoiceRepository;
        }

        public void ExportToPDF(Invoice invoice, string file)
        {
            _repositoryPDF.Export(invoice, file);
        }

        public void ExportToXML(Invoice invoice, string file)
        {
            _repositoryXML.Export(invoice, file);
        }


        public Invoice GetById(int id)
        {
            return _issuedInvoiceRepository.GetById(id);
        }

        public IQueryable<Invoice> GetAll()
        {
            return _issuedInvoiceRepository.GetAll();
        }
    }
}
