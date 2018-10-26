using Projeto_NFe.Domain.Features.ProductTaxes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.ProductsTaxes
{
    public class ProductTaxConfiguration : EntityTypeConfiguration<ProductTax>
    {
        public ProductTaxConfiguration()
        {
            ToTable("TBProductTax");
            HasKey(t => t.Id);
            Property(t => t.IcmsAliquot).IsRequired();
            Property(t => t.IpiAliquot).IsRequired();
            Property(t => t.IcmsValue).IsOptional();
            Property(t => t.IpiValue).IsOptional();
        }
    }
}
