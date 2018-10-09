using Projeto_NFe.Infra.XML.Features.InvoiceTaxes;
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
    public class InvoiceAmountModel
    {
        [XmlElement(ElementName = "ICMSTot")]
        public InvoiceTaxModel ICMSTot { get; set; }
    }
}
