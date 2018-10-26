using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.SoldProducts;
using Projeto_NFe.Infra.PDF.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.SoldProducts
{
    public class SoldProductMapper
    {
        ProductTaxMapper _taxMap;

        public void Map(AcroFields fields, IEnumerable<SoldProductModel> productsModel)
        {
            _taxMap = new ProductTaxMapper();

            int orderProduct = 0;
            foreach(SoldProductModel productModel in productsModel)
            {
                fields.SetField("DET_PROD_CPROD." + orderProduct, productModel.Code);
                fields.SetField("DET_PROD_XPROD." + orderProduct, productModel.Description);
                fields.SetField("DET_PROD_QCOM." + orderProduct, productModel.Quantity.ToString());
                fields.SetField("DET_PROD_VPROD." + orderProduct, productModel.Amount.ToString());
                _taxMap.Map(fields, orderProduct, productModel.Tax);
                fields.SetField("DET_PROD_VUNCOM." + orderProduct, productModel.UnitaryValue.ToString());
                fields.SetField("DET_IMPOSTO_ICMS_ICMS_VBC." + orderProduct, productModel.Amount.ToString());
                orderProduct++;
            }
        }
    }
}
