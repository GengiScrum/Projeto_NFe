using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Infra.PDF.Features.Addresses;

namespace Projeto_NFe.Infra.PDF.Features.Issuers
{
    public class IssuerModel
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalRegistration { get; set; }
        public AddressModel Address { get; set; }

        public void Create(Issuer issuer)
        {
            Cnpj = issuer.Cnpj;
            Address = new AddressModel();
            Address.Neighborhood = issuer.Address.Neighborhood;
            Address.State = issuer.Address.State;
            Address.StreetName = issuer.Address.StreetName;
            Address.City = issuer.Address.City;
            Address.Number = issuer.Address.Number;
            Address.Country = issuer.Address.Country;
            StateRegistration = issuer.StateRegistration;
            MunicipalRegistration = issuer.MunicipalRegistration;
            BusinessName = issuer.BusinessName;
            CorporateName = issuer.CorporateName;
        }
    }
}
