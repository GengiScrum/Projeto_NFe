using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
using Projeto_NFe.Infra.ORM.Features.Invoices;
using Projeto_NFe.Infra.ORM.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.ORM.Contexts
{
    public class NFeContext : DbContext
    {
        public NFeContext(string connection = "Name=NFeContext") : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = true;
            
        }

        protected NFeContext(DbConnection connection) : base(connection, true) { }

        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<Issuer> Issuers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
