using Projeto_NFe.Domain.Features.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.ShippingCompanies
{
    public class ShippingCompanyConfiguration : EntityTypeConfiguration<ShippingCompany>
    {
        public ShippingCompanyConfiguration()
        {
            this.ToTable("TBShippingCompany");
            this.HasKey(t => t.Id);
            this.Property(t => t.BusinessName).HasMaxLength(40);
            this.Property(t => t.CorporateName).HasMaxLength(40);
            this.Property(t => t.StateRegistration).HasMaxLength(40);
            this.Property(t => t.Cpf).HasMaxLength(15);
            this.Property(t => t.Cnpj).HasMaxLength(19);
            this.Property(t => t.PersonType).IsRequired();
            this.Property(t => t.ShippingResponsability).IsRequired();
            this.Property(t => t.Address.Country).HasColumnName("Country").IsRequired().HasMaxLength(40);
            this.Property(t => t.Address.State).HasColumnName("State").IsRequired().HasMaxLength(40);
            this.Property(t => t.Address.City).HasColumnName("City").IsRequired().HasMaxLength(40);
            this.Property(t => t.Address.Neighborhood).HasColumnName("Neighborhood").IsRequired().HasMaxLength(40);
            this.Property(t => t.Address.StreetName).HasColumnName("StreetName").IsRequired().HasMaxLength(40);
            this.Property(t => t.Address.Number).HasColumnName("Number").IsRequired();
        }
    }
}
