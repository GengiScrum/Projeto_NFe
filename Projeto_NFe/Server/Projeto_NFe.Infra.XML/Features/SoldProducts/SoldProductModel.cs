using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.SoldProducts
{
    [ExcludeFromCodeCoverage]
    public class SoldProductModel
    {
        [XmlElement(ElementName = "cProd")]
        public string CodeProduct { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string DescriptionProduct { get; set; }

        [XmlElement(ElementName = "qCom")]
        public int Quantity { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public double UnitaryValue { get; set; }

        [XmlElement(ElementName = "vProd")]
        public double Amount { get; set; }
    }
}
