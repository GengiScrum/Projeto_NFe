using iTextSharp.text.pdf;

namespace Projeto_NFe.Infra.PDF.Features.Issuers
{
    public class IssuerMapper
    {
        public void Map(AcroFields fields, IssuerModel issuerModel)
        {
            fields.SetField("NOME", issuerModel.BusinessName);
            fields.SetField("LOGRADOURO", issuerModel.Address.StreetName);
            fields.SetField("BAIRRO", issuerModel.Address.Neighborhood);
            fields.SetField("CEP", issuerModel.Address.City + " - " + issuerModel.Address.State);
            fields.SetField("EMIT_IE", issuerModel.StateRegistration);
            fields.SetField("EMIT_Cnpj", issuerModel.Cnpj);
        }
    }
}
