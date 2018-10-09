using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.ShippingCompanies.ViewModel
{
    public class ShippingCompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public bool ShippingResponsability { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int PersonType { get; set; }
    }
}
