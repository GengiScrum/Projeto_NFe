using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Addresses
{
    public class Address
    {
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual void Validate()
        {
            //if (StreetName.Length < 4 || StreetName.Length > 100)
            //    throw new AddressStreetNameCaracteresExcecao();
            //if (Number < 1 || Number > 9999)
            //    throw new AddressNumberInvalidExcecao();
            //if (Neighborhood.Length < 4 || Neighborhood.Length > 40)
            //    throw new AddressNeighborhoodCaracteresExcecao();
            //if (City.Length < 4 || City.Length > 40)
            //    throw new AddressCityCaracteresExcecao();
            //if (State.Length < 2 || State.Length > 40)
            //    throw new AddressStateCaracteresExcecao();
            //if (Country.Length < 4 || Country.Length > 40)
            //    throw new AddressCountryCaracteresExcecao();
        }
    }
}
