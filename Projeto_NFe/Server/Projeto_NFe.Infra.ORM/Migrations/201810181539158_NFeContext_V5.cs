namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TBInvoice", "IssueDate");
            DropColumn("dbo.TBInvoice", "AccesKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBInvoice", "AccesKey", c => c.String(maxLength: 44, unicode: false));
            AddColumn("dbo.TBInvoice", "IssueDate", c => c.DateTime(nullable: false));
        }
    }
}
