using Projeto_NFe.Infra.XML.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.Invoices
{
    [ExcludeFromCodeCoverage]
    [XmlRoot("NFe")]
    public class InvoiceXmlModel
    {
        [XmlElement(ElementName = "infNFe")]
        public InfNFeModel infNFe { get; set; }
    }
}
