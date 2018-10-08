using Projeto_NFe.Application.Features.Products;
using System.Data.Entity.ModelConfiguration;

namespace Projeto_NFe.Infra.ORM.Features.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("TBProduct");
            HasKey(p => p.Id);
            Property(p => p.Code).IsRequired();
            Property(p => p.Description).IsRequired();
            Property(p => p.UnitaryValue).IsRequired();
        }
    }
}
