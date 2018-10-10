using Projeto_NFe.Infra.XML.Features.Addresses;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Issuers
{
    [ExcludeFromCodeCoverage]
    public class IssuerModel
    {
        [XmlElement(ElementName = "Cnpj")]
        public string CnpjIssuer { get; set; }

        [XmlElement(ElementName = "xName")]
        public string CorporateName { get; set; }

        [XmlElement(ElementName = "xFant")]
        public string Name { get; set; }

        [XmlElement(ElementName = "IE")]
        public string StateRegistration { get; set; }

        [XmlElement(ElementName = "IM")]
        public string MunicipalRegistration { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public AddressModel enderEmit { get; set; }
    }
}
