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
            ToTable("TBShippingCompany");
            HasKey(t => t.Id);
            Property(t => t.BusinessName).HasMaxLength(40);
            Property(t => t.CorporateName).HasMaxLength(40);
            Property(t => t.StateRegistration).HasMaxLength(40);
            Property(t => t.Cpf).HasMaxLength(15);
            Property(t => t.Cnpj).HasMaxLength(19);
            Property(t => t.PersonType).IsRequired();
            Property(t => t.ShippingResponsability).IsRequired();
            Property(t => t.Address.Country).HasColumnName("Country").IsRequired().HasMaxLength(40);
            Property(t => t.Address.State).HasColumnName("State").IsRequired().HasMaxLength(40);
            Property(t => t.Address.City).HasColumnName("City").IsRequired().HasMaxLength(40);
            Property(t => t.Address.Neighborhood).HasColumnName("Neighborhood").IsRequired().HasMaxLength(40);
            Property(t => t.Address.StreetName).HasColumnName("StreetName").IsRequired().HasMaxLength(40);
            Property(t => t.Address.Number).HasColumnName("Number").IsRequired();
        }
    }
}
