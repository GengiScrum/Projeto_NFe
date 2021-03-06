﻿using Projeto_NFe.Infra.XML.Features.ProductTaxes;
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
    public class SoldProductsModel
    {
        [XmlAttribute(AttributeName = "nItem")]
        public int nItemNumber { get; set; }

        [XmlElement(ElementName = "prod")]
        public SoldProductModel Prod { get; set; }

        [XmlElement(ElementName = "tax")]
        public TaxModel Tax { get; set; }
    }
}
