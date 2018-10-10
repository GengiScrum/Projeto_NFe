using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Addresses
{
    [ExcludeFromCodeCoverage]
    public class AddressModel
    {
        [XmlElement(ElementName = "xLgr")]
        public string StreetName { get; set; }

        [XmlElement(ElementName = "nro")]
        public int Number { get; set; }

        [XmlElement(ElementName = "xNeighborhood")]
        public string Neighborhood { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string City { get; set; }

        [XmlElement(ElementName = "UF")]
        public string State { get; set; }

        [XmlElement(ElementName = "xCountry")]
        public string Country { get; set; }
    }
}
