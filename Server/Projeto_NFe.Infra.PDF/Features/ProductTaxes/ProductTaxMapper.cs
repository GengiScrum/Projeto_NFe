using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.ProductTaxes
{
    public class ProductTaxMapper
    {
        public void Map(AcroFields fields, int orderProduct, ProductTaxModel taxModel)
        {
            fields.SetField("DET_IMPOSTO_ICMS_ICMS_PICMS." + orderProduct, taxModel.IcmsAliquot.ToString());
            fields.SetField("DET_IMPOSTO_IPI_IPITRIB_PIPI." + orderProduct, taxModel.IpiAliquot.ToString());
            fields.SetField("DET_IMPOSTO_IPI_IPITRIB_VIPI." + orderProduct, taxModel.IpiValue.ToString());
            fields.SetField("DET_IMPOSTO_ICMS_ICMS_VICMS." + orderProduct, taxModel.IcmsValue.ToString());
        }
    }
}
