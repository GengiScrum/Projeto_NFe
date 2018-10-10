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
            Property(p => p.Code).HasMaxLength(40).IsRequired();
            Property(p => p.Description).HasMaxLength(40).IsRequired();
            Property(p => p.UnitaryValue).IsRequired();
        }
    }
}
