﻿using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.SoldProducts;
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

            Property(invoice => invoice.OperationNature).HasColumnType("varchar").HasColumnName("OperationNature").IsOptional();

            Property(invoice => invoice.EntryDate).HasColumnType("datetime").HasColumnName("EntryDate");

            Ignore(invoice => invoice.IssueDate);

            Ignore(invoice => invoice.AcessKey);

            Property(invoice => invoice.AddresseeId).HasColumnName("AddresseeId");
            HasOptional(invoice => invoice.Addressee)
            .WithMany()
            .HasForeignKey(invoice => invoice.AddresseeId);

            Property(invoice => invoice.InvoiceTaxId).HasColumnName("InvoiceTaxId");
            HasOptional(invoice => invoice.InvoiceTax)
            .WithMany()
            .HasForeignKey(invoice => invoice.InvoiceTaxId);

            HasMany(invoice => invoice.SoldProducts).WithRequired(p => p.Invoice).HasForeignKey(p => p.InvoiceId).WillCascadeOnDelete();

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
