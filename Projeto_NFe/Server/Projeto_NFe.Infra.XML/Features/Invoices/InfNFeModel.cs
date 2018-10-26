using Projeto_NFe.Infra.XML.Features.Addressees;
using Projeto_NFe.Infra.XML.Features.Issuers;
using Projeto_NFe.Infra.XML.Features.Invoices;
using Projeto_NFe.Infra.XML.Features.SoldProducts;
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
    public class InfNFeModel
    {
        [XmlAttribute(AttributeName = "Id")]
        public string AcessKey { get; set; }

        [XmlAttribute(AttributeName = "Versao")]
        public string Versao { get; set; }

        [XmlElement(ElementName = "ide")]
        public IdeModel ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public IssuerModel emit { get; set; }

        [XmlElement(ElementName = "dest")]
        public AddresseeModel dest { get; set; }

        [XmlArrayItem("det")]
        public List<SoldProductsModel> det { get; set; }

        [XmlElement(ElementName = "total")]
        public InvoiceAmountModel total { get; set; }
    }
}
