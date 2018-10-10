namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBAddressee", "CorporateName", c => c.String(maxLength: 40));
            AlterColumn("dbo.TBAddressee", "StateRegistration", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBAddressee", "StateRegistration", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.TBAddressee", "CorporateName", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
