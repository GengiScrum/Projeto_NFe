using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Infra.PDF.Features.Addresses;

namespace Projeto_NFe.Infra.PDF.Features.Addressees
{
    public class AddresseeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public AddressModel Address { get; set; }
        public EnumPersonType PersonType { get; set; }

        public void Create(Addressee addressee)
        {
            Cnpj = addressee.Cnpj;
            Cpf = addressee.Cpf;
            Address = new AddressModel();
            Address.Neighborhood = addressee.Address.Neighborhood;
            Address.State = addressee.Address.State;
            Address.StreetName = addressee.Address.StreetName;
            Address.City = addressee.Address.City;
            Address.Number = addressee.Address.Number;
            Address.Country = addressee.Address.Country;
            Id = addressee.Id;
            StateRegistration = addressee.StateRegistration;
            Name = addressee.BusinessName;
            CorporateName = addressee.CorporateName;
            PersonType = addressee.PersonType;
        }
    }
}
