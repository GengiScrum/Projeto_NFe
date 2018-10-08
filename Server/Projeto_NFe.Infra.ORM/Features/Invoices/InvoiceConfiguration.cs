using Projeto_NFe.Domain.Features.Invoices;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.Invoices
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            ToTable("TBInvoice");

            HasKey(invoice => invoice.Id);

            Property(invoice => invoice.AcessKey).HasColumnType("varchar").HasColumnName("AccesKey").HasMaxLength(44); ;

            Property(invoice => invoice.OperationNature).HasColumnType("varchar").HasColumnName("OperationNature").IsOptional();

            Property(invoice => invoice.EntryDate).HasColumnType("datetime").HasColumnName("EntryDate");

            Property(invoice => invoice.IssueDate).HasColumnType("datetime").HasColumnName("IssueDate");

            Property(invoice => invoice.AddresseeId).HasColumnName("AddresseeId");
            HasOptional(invoice => invoice.Addressee)
            .WithMany()
            .HasForeignKey(invoice => invoice.AddresseeId);

            Property(invoice => invoice.InvoiceTaxId).HasColumnName("InvoiceTaxId");
            HasOptional(invoice => invoice.Tax)
            .WithMany()
            .HasForeignKey(invoice => invoice.InvoiceTaxId);

            Property(invoice => invoice.ShippingCompanyId).HasParameterName("ShippingCompanyId");
            HasOptional(invoice => invoice.ShippingCompany)
            .WithMany()
            .HasForeignKey(invoice => invoice.ShippingCompanyId);

            Property(invoice => invoice.IssuerId).HasParameterName("IssuerId");
            HasOptional(invoice => invoice.Issuer)
            .WithMany()
            .HasForeignKey(invoice => invoice.IssuerId);

        }
    }
}
