using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.PDF.Features.Addresses;
using Projeto_NFe.Infra.PDF.Features.Invoices;
using Projeto_NFe.Infra.PDF.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.Addressees
{
    public class AddresseeMapper
    {
        public void Map(AcroFields fields, AddresseeModel addresseeModel)
        {
            fields.SetField("DEST_XNOME", addresseeModel.Name);
            fields.SetField("DEST_Cnpj", addresseeModel.Cnpj);
            fields.SetField("DEST_ENDERDEST_XLGR", addresseeModel.Address.StreetName);
            fields.SetField("DEST_ENDERDEST_XBAIRRO", addresseeModel.Address.Neighborhood);
            fields.SetField("DEST_ENDERDEST_XMUN", addresseeModel.Address.City);
            fields.SetField("DEST_ENDERDEST_UF", addresseeModel.Address.State);
            fields.SetField("DEST_ENDERDEST_NRO", addresseeModel.Address.Number.ToString());
            fields.SetField("DEST_IE", addresseeModel.StateRegistration);
        }
    }
}
