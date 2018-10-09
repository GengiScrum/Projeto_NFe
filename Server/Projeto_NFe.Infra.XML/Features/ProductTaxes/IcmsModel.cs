﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.XML.Features.ProductTaxes
{
    [ExcludeFromCodeCoverage]
    public class IcmsModel
    {

        [XmlElement(ElementName = "ICMS00")]
        public IcmsProductModel IcmsProduct { get; set; }
    }
}
