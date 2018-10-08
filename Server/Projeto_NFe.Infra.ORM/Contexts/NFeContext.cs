using Projeto_NFe.Domain.Features.Addressees;
using Projeto_NFe.Domain.Features.Issuers;
using Projeto_NFe.Domain.Features.ShippingCompanies;
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
        public DbSet<Addressee> Addressees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
