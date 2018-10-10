using Projeto_NFe.Domain.Features.Issuers;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Issuers
{
    public class IssuerConfiguration : EntityTypeConfiguration<Issuer>
    {
        public IssuerConfiguration()
        {
            ToTable("TBIssuer");
            HasKey(e => e.Id);
            Property(e => e.Cnpj).HasMaxLength(40).IsRequired();
            Property(e => e.StateRegistration).HasMaxLength(40).IsRequired();
            Property(e => e.MunicipalRegistration).HasMaxLength(40).IsRequired();
            Property(e => e.BusinessName).HasMaxLength(40).IsRequired();
            Property(e => e.CorporateName).HasMaxLength(40).IsRequired();
            Property(e => e.Address.Country).HasMaxLength(40).HasColumnName("Country").IsRequired();
            Property(e => e.Address.State).HasMaxLength(40).HasColumnName("State").IsRequired();
            Property(e => e.Address.City).HasMaxLength(40).HasColumnName("City").IsRequired();
            Property(e => e.Address.Neighborhood).HasMaxLength(40).HasColumnName("Neighborhood").IsRequired();
            Property(e => e.Address.StreetName).HasMaxLength(40).HasColumnName("StreetName").IsRequired();
            Property(e => e.Address.Number).HasColumnName("Number").IsRequired();
        }
    }
}
