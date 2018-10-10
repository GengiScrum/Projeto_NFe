using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.PDF.Features.Addressees;

namespace Projeto_NFe.Infra.PDF.Features.ShippingCompanies
{
    public class ShippingCompanyMapper
    {
        public void Map(AcroFields fields, ShippingCompanyModel shippingCompanyModel, AddresseeModel addresseeModel)
        {
            if (shippingCompanyModel != null)
            {
                fields.SetField("TRANSP_TRANSPORTA_XNOME", shippingCompanyModel.Name);
                fields.SetField("TRANSP_TRANSPORTA_XENDER", shippingCompanyModel.Address.StreetName);
                if (shippingCompanyModel.ShippingResponsability)
                    fields.SetField("TRANSP_MODFRETE", "1");
                else
                    fields.SetField("TRANSP_MODFRETE", "0");
                if (shippingCompanyModel.PersonType == EnumPersonType.PessoaFisica)
                    fields.SetField("TRANSP_TRANSPORTA_Cpf", shippingCompanyModel.Cpf);
                else
                    fields.SetField("TRANSP_TRANSPORTA_Cnpj", shippingCompanyModel.Cnpj);
                fields.SetField("TRANSP_TRANSPORTA_IE", shippingCompanyModel.StateRegistration);
                fields.SetField("TRANSP_TRANSPORTA_XMUN", shippingCompanyModel.Address.City);
                fields.SetField("TRANSP_TRANSPORTA_UF", shippingCompanyModel.Address.State);
            }
            if (shippingCompanyModel == null)
            {
                fields.SetField("TRANSP_TRANSPORTA_XNOME", addresseeModel.Name);
                fields.SetField("TRANSP_TRANSPORTA_XENDER", addresseeModel.Address.StreetName);
                fields.SetField("TRANSP_MODFRETE", "9");
                if (addresseeModel.PersonType == EnumPersonType.PessoaFisica)
                    fields.SetField("TRANSP_TRANSPORTA_Cpf", addresseeModel.Cpf);
                else
                    fields.SetField("TRANSP_TRANSPORTA_Cnpj", addresseeModel.Cnpj);
                fields.SetField("TRANSP_TRANSPORTA_IE", addresseeModel.StateRegistration);
                fields.SetField("TRANSP_TRANSPORTA_XMUN", addresseeModel.Address.City);
                fields.SetField("TRANSP_TRANSPORTA_UF", addresseeModel.Address.State);
            }
        }
    }
}
