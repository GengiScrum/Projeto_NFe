using Projeto_NFe.Infra.XML.Features.Addresses;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Addressees
{
    [ExcludeFromCodeCoverage]
    public class AddresseeModel
    {
        [XmlElement(ElementName = "Cnpj")]
        public string CnpjAddressee { get; set; }

        [XmlElement(ElementName = "Cpf")]
        public string CpfAddressee { get; set; }

        [XmlElement(ElementName = "xName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "indIEDest")]
        public string StateRegistration { get; set; }

        [XmlElement(ElementName = "enderDest")]
        public AddressModel enderDest { get; set; }
    }
}
