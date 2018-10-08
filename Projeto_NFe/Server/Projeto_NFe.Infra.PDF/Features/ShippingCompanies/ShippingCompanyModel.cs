using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.PDF.Features.Addresses;

namespace Projeto_NFe.Infra.PDF.Features.ShippingCompanies
{
    public class ShippingCompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public bool ShippingResponsability { get; set; }
        public AddressModel Address { get; set; }
        public EnumPersonType PersonType { get; set; }

        public void Create(ShippingCompany shippingCompany)
        {
            Cnpj = shippingCompany.Cnpj;
            Cpf = shippingCompany.Cpf;
            Address = new AddressModel();
            Address.Neighborhood = shippingCompany.Address.Neighborhood;
            Address.State = shippingCompany.Address.State;
            Address.StreetName = shippingCompany.Address.StreetName;
            Address.City = shippingCompany.Address.City;
            Address.Number = shippingCompany.Address.Number;
            Address.Country = shippingCompany.Address.Country;
            Id = shippingCompany.Id;
            StateRegistration = shippingCompany.StateRegistration;
            Name = shippingCompany.BusinessName;
            CorporateName = shippingCompany.CorporateName;
            ShippingResponsability = shippingCompany.ShippingResponsability;
            PersonType = shippingCompany.PersonType;
        }
    }
}
