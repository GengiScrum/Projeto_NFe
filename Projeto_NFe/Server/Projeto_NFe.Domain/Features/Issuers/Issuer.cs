using Projeto_NFe.Domain.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.Issuers
{
    public class Issuer
    {
        public virtual int Id { get; set; }
        public string BusinessName { get; set; }
        public string CorporateName { get; set; }
        public string Cnpj { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalRegistration { get; set; }

        public Address Address { get; set; }
    }
}
