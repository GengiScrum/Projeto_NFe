using Projeto_NFe.Domain.Features.SoldProducts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.SoldProducts
{
    public class SoldProductConfiguration : EntityTypeConfiguration<SoldProduct>
    {
        public SoldProductConfiguration()
        {
            ToTable("TBSoldProduct");
            HasKey(p => p.Id);
            HasRequired(p => p.Product).WithMany().HasForeignKey(p => p.ProductId);
        }
    }
}
