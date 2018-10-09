using Projeto_NFe.Domain.Features.IssuedInvoices;
using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.IssuedInvoices;
using Projeto_NFe.Infra.PDF.Features.Invoices;

namespace Projeto_NFe.Application.Features.IssuedInvoices
{
    public class IssuedInvoiceService : IIssuedInvoiceService
    {
        IIssuedInvoiceXMLRepository _repositoryXML;
        IInvoicePDFRepository _repositoryPDF;

        public IssuedInvoiceService(IIssuedInvoiceXMLRepository repositoryXML, IInvoicePDFRepository repositoryPDF)
        {
            _repositoryXML = repositoryXML;
            _repositoryPDF = repositoryPDF;
        }

        public void ExportToPDF(Invoice invoice, string file)
        {
            _repositoryPDF.Export(invoice, file);
        }

        public void ExportToXML(Invoice invoice, string file)
        {
            _repositoryXML.Export(invoice, file);
        }
    }
}
