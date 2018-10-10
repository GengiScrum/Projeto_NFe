using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.InvoiceTaxes
{
    public class InvoiceTaxMapper
    {
        public void Map(AcroFields fields, InvoiceTaxModel taxInvoiceModel)
        {
            fields.SetField("TOTAL_ICMSTOT_VBC", taxInvoiceModel.ProductAmount.ToString());
            fields.SetField("TOTAL_ICMSTOT_VFRETE", taxInvoiceModel.ShippingValue.ToString());
            fields.SetField("TOTAL_ICMSTOT_VICMS", taxInvoiceModel.InvoiceIcmsValue.ToString());
            fields.SetField("TOTAL_ICMSTOT_VPROD", taxInvoiceModel.ProductAmount.ToString());
            fields.SetField("TOTAL_ICMSTOT_VIPI", taxInvoiceModel.InvoiceIpiValue.ToString());
            fields.SetField("TOTAL_ICMSTOT_VNF", taxInvoiceModel.InvoiceAmount.ToString());
        }
    }
}
