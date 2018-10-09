namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V21 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TBShippingCompany", name: "County", newName: "Country");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.TBShippingCompany", name: "Country", newName: "County");
        }
    }
}
