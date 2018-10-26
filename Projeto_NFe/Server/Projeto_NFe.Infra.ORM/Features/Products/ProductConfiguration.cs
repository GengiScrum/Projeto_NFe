using Projeto_NFe.Domain.Features.Products;
using System.Data.Entity.ModelConfiguration;

namespace Projeto_NFe.Infra.ORM.Features.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("TBProduct");
            HasKey(p => p.Id);
            Property(p => p.Code).IsRequired().HasMaxLength(40);
            Property(p => p.Description).IsRequired().HasMaxLength(40);
            Property(p => p.UnitaryValue).IsRequired();
            HasOptional(p => p.Tax);
        }
    }
}
