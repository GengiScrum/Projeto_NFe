using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.ProductTaxes
{
    [ExcludeFromCodeCoverage]
    public class IcmsProductModel
    {
        [XmlElement(ElementName = "pICMS")]
        public double IcmsAliquota { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public double IcmsAmount { get; set; }
    }
}
