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
    public class IdeModel
    {
        [XmlElement(ElementName = "natOp")]
        public string OperationNature { get; set; }

        [XmlElement(ElementName = "dhEmi")]
        public DateTime IssueDate { get; set; }
    }
}
