namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBIssuer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(nullable: false, maxLength: 40),
                        CorporateName = c.String(nullable: false, maxLength: 40),
                        Cnpj = c.String(nullable: false, maxLength: 40),
                        StateRegistration = c.String(nullable: false, maxLength: 40),
                        MunicipalRegistration = c.String(nullable: false, maxLength: 40),
                        StreetName = c.String(nullable: false, maxLength: 40),
                        Number = c.Int(nullable: false),
                        Neighborhood = c.String(nullable: false, maxLength: 40),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        Country = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBShippingCompany",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 40),
                        CorporateName = c.String(maxLength: 40),
                        Cnpj = c.String(maxLength: 19),
                        Cpf = c.String(maxLength: 15),
                        StateRegistration = c.String(maxLength: 40),
                        ShippingResponsability = c.Boolean(nullable: false),
                        StreetName = c.String(nullable: false, maxLength: 40),
                        Number = c.Int(nullable: false),
                        Neighborhood = c.String(nullable: false, maxLength: 40),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        County = c.String(nullable: false, maxLength: 40),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBShippingCompany");
            DropTable("dbo.TBIssuer");
        }
    }
}
