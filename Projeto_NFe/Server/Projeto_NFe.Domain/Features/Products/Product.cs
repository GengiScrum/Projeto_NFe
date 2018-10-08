using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Features.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double UnitaryValue { get; set; }

        public virtual void Validate()
        {
        }
    }
}
