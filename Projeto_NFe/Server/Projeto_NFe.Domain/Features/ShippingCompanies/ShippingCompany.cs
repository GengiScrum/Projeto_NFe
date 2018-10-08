using Projeto_NFe.Domain.Utils;
using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ShippingCompanies
{
    public class ShippingCompany
    {
        public virtual int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string StateRegistration { get; set; }
        public bool ShippingResponsability { get; set; }
        public Address Address { get; set; }
        public EnumPersonType PersonType { get; set; }
    }
}
