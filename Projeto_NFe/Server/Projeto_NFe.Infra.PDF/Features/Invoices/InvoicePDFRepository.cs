using iTextSharp.text;
using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.Invoices
{
    public class InvoicePDFRepository : IInvoicePDFRepository
    {
        InvoiceMapper _invoiceMap;
        InvoiceModel _invoiceModel;

        public void Export(Invoice invoice, string path)
        {
            EscreverPdf(invoice, path);
        }

        private void EscreverPdf(Invoice invoice, string path)
        {
            _invoiceMap = new InvoiceMapper();
            _invoiceModel = new InvoiceModel();
            _invoiceModel.Create(invoice);

            string modeloPdf = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\Projeto_NFe.Infra.PDF\\ModelsPDF\\NFEM_PAG1.pdf";
            string newPdf = path;

            using (var modeloPdfStream = new FileStream(modeloPdf, FileMode.Open))
            using (var newPdfStream = new FileStream(newPdf, FileMode.Create))
            {
                var pdfReader = new PdfReader(modeloPdfStream);

                var pdfStamp = new PdfStamper(pdfReader, newPdfStream);

                _invoiceMap.Map(pdfStamp, _invoiceModel);

                pdfStamp.FormFlattening = true;
                pdfStamp.PartialFormFlattening("field1");

                pdfStamp.Close();
                pdfReader.Close();
            }
        } 
    }
}
