namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TBProduct", "Tax_Id", "dbo.TBProductTax");
            DropIndex("dbo.TBProduct", new[] { "Tax_Id" });
            AlterColumn("dbo.TBProduct", "Tax_Id", c => c.Int());
            CreateIndex("dbo.TBProduct", "Tax_Id");
            AddForeignKey("dbo.TBProduct", "Tax_Id", "dbo.TBProductTax", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBProduct", "Tax_Id", "dbo.TBProductTax");
            DropIndex("dbo.TBProduct", new[] { "Tax_Id" });
            AlterColumn("dbo.TBProduct", "Tax_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TBProduct", "Tax_Id");
            AddForeignKey("dbo.TBProduct", "Tax_Id", "dbo.TBProductTax", "Id", cascadeDelete: true);
        }
    }
}
