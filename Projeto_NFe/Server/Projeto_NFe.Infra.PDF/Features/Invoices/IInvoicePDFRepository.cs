using Projeto_NFe.Domain.Features.Invoices;

namespace Projeto_NFe.Infra.PDF.Features.Invoices
{
    public interface IInvoicePDFRepository
    {
        void Export(Invoice invoice, string path);
    }
}
