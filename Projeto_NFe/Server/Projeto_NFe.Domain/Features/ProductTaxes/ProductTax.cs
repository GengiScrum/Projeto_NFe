using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Features.ProductTaxes
{
    public class ProductTax
    {
        public int Id { get; set; }
        public double IpiValue { get; set; }
        public double IcmsValue { get; set; }
        public double IpiAliquot { get { return 10; } set { } }
        public double IcmsAliquot { get { return 4; } set { } }

        public void CalculateIpi(double amount)
        {
            IpiValue = amount * (IpiAliquot/100);
        }

        public void CalculateIcms(double amount)
        {
            IcmsValue = amount * (IcmsAliquot/100);
        }
    }
}
