using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.PDF.Features.ProductTaxes
{
    public class ProductTaxModel
    {
        public int Id { get; set; }
        public double IpiValue { get; set; }
        public double IcmsValue { get; set; }
        public double IpiAliquot { get { return 10; } set { } }
        public double IcmsAliquot { get { return 4; } set { } }

        public void Create(ProductTax tax)
        {
            IcmsAliquot = tax.IcmsAliquot;
            IpiAliquot = tax.IpiAliquot;
            Id = tax.Id;
            IcmsValue = tax.IcmsValue;
            IpiValue = tax.IpiValue;
        }
    }
}
