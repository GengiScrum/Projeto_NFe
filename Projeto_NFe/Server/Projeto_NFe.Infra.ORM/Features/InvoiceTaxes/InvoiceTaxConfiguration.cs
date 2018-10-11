using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.InvoiceTaxes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Features.InvoiceTaxes
{
    public class InvoiceTaxConfiguration : EntityTypeConfiguration<InvoiceTax>
    {
        public InvoiceTaxConfiguration()
        {
            ToTable("TBInvoiceTax");

            HasKey(invoiceTax => invoiceTax.Id);

            Property(invoiceTax => invoiceTax.InvoiceAmount).HasColumnType("float").IsRequired();
            Property(invoiceTax => invoiceTax.InvoiceIcmsValue).HasColumnType("float").IsRequired();
            Property(invoiceTax => invoiceTax.InvoiceIpiValue).HasColumnType("float").IsRequired();
            Property(invoiceTax => invoiceTax.ProductAmount).HasColumnType("float").IsRequired();
            Property(invoiceTax => invoiceTax.ShippingValue).HasColumnType("float").IsRequired();

        }
    }
}

