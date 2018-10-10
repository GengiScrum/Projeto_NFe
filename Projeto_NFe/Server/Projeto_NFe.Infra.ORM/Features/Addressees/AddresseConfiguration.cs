using Projeto_NFe.Domain.Features.Addressees;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Addressees
{
    public class AddresseeConfiguration : EntityTypeConfiguration<Addressee>
    {
        public AddresseeConfiguration()
        {
            ToTable("TBAddressee");
            HasKey(e => e.Id);
            Property(a => a.Cnpj).HasMaxLength(40).IsOptional();
            Property(a => a.Cpf).HasMaxLength(40).IsOptional();
            Property(a => a.StateRegistration).HasMaxLength(40).IsOptional();
            Property(a => a.CorporateName).HasMaxLength(40).IsOptional();
            Property(a => a.BusinessName).HasMaxLength(40).IsRequired();
            Property(a => a.Address.Country).HasMaxLength(40).HasColumnName("Country").IsRequired();
            Property(a => a.Address.State).HasMaxLength(40).HasColumnName("State").IsRequired();
            Property(a => a.Address.City).HasMaxLength(40).HasColumnName("City").IsRequired();
            Property(a => a.Address.Neighborhood).HasMaxLength(40).HasColumnName("Neighborhood").IsRequired();
            Property(a => a.Address.StreetName).HasMaxLength(40).HasColumnName("StreetName").IsRequired();
            Property(a => a.Address.Number).HasColumnName("Number").IsRequired();
        }
    }
}
