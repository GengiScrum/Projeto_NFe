using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.InvoiceTaxes
{
    [ExcludeFromCodeCoverage]
    public class InvoiceTaxModel
    {
        [XmlElement(ElementName = "vICMS")]
        public double IcmsValue { get; set; }

        [XmlElement(ElementName = "vFrete")]
        public double ShippingValue { get; set; }

        [XmlElement(ElementName = "vIPI")]
        public double IpiValue { get; set; }

        [XmlElement(ElementName = "vNF")]
        public double ValueProducts { get; set; }

        [XmlElement(ElementName = "vTotTrib")]
        public double InvoiceAmount { get; set; }
    }
}
