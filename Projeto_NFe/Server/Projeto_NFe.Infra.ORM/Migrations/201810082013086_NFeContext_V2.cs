namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBAddressee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false, maxLength: 40),
                        CorporateName = c.String(maxLength: 40),
                        Cnpj = c.String(maxLength: 40),
                        Cpf = c.String(maxLength: 40),
                        StateRegistration = c.String(maxLength: 40),
                        StreetName = c.String(nullable: false, maxLength: 40),
                        Number = c.Int(nullable: false),
                        Neighborhood = c.String(nullable: false, maxLength: 40),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        Country = c.String(nullable: false, maxLength: 40),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBAddressee");
        }
    }
}
