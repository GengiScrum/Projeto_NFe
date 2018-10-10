namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBShippingCompany", "BusinessName", c => c.String(maxLength: 40));
            DropColumn("dbo.TBShippingCompany", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBShippingCompany", "Name", c => c.String(maxLength: 40));
            DropColumn("dbo.TBShippingCompany", "BusinessName");
        }
    }
}
