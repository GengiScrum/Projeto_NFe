namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 40),
                        UnitaryValue = c.Double(nullable: false),
                        IdProductSold = c.Int(),
                        Quantity = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Tax_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductTaxes", t => t.Tax_Id)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.ProductTaxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpiValue = c.Double(nullable: false),
                        IcmsValue = c.Double(nullable: false),
                        IpiAliquot = c.Double(nullable: false),
                        IcmsAliquot = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TBShippingCompany", "BusinessName", c => c.String(maxLength: 40));
            DropColumn("dbo.TBShippingCompany", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBShippingCompany", "Name", c => c.String(maxLength: 40));
            DropForeignKey("dbo.TBProduct", "Tax_Id", "dbo.ProductTaxes");
            DropIndex("dbo.TBProduct", new[] { "Tax_Id" });
            DropColumn("dbo.TBShippingCompany", "BusinessName");
            DropTable("dbo.ProductTaxes");
            DropTable("dbo.TBProduct");
        }
    }
}
