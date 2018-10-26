namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V1 : DbMigration
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
            
            CreateTable(
                "dbo.TBInvoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssuerId = c.Int(),
                        ShippingCompanyId = c.Int(),
                        AddresseeId = c.Int(),
                        InvoiceTaxId = c.Int(),
                        OperationNature = c.String(maxLength: 8000, unicode: false),
                        EntryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBAddressee", t => t.AddresseeId)
                .ForeignKey("dbo.TBInvoiceTax", t => t.InvoiceTaxId)
                .ForeignKey("dbo.TBIssuer", t => t.IssuerId)
                .ForeignKey("dbo.TBShippingCompany", t => t.ShippingCompanyId)
                .Index(t => t.IssuerId)
                .Index(t => t.ShippingCompanyId)
                .Index(t => t.AddresseeId)
                .Index(t => t.InvoiceTaxId);
            
            CreateTable(
                "dbo.TBInvoiceTax",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceIpiValue = c.Double(nullable: false),
                        InvoiceIcmsValue = c.Double(nullable: false),
                        ShippingValue = c.Double(nullable: false),
                        ProductAmount = c.Double(nullable: false),
                        InvoiceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        BusinessName = c.String(maxLength: 40),
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
                        Country = c.String(nullable: false, maxLength: 40),
                        PersonType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TBSoldProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBProduct", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.TBInvoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.TBProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 40),
                        Description = c.String(nullable: false, maxLength: 40),
                        UnitaryValue = c.Double(nullable: false),
                        Tax_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TBProductTax", t => t.Tax_Id, cascadeDelete: true)
                .Index(t => t.Tax_Id);
            
            CreateTable(
                "dbo.TBProductTax",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpiValue = c.Double(),
                        IcmsValue = c.Double(),
                        IpiAliquot = c.Double(nullable: false),
                        IcmsAliquot = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBSoldProduct", "InvoiceId", "dbo.TBInvoice");
            DropForeignKey("dbo.TBSoldProduct", "Product_Id", "dbo.TBProduct");
            DropForeignKey("dbo.TBProduct", "Tax_Id", "dbo.TBProductTax");
            DropForeignKey("dbo.TBInvoice", "ShippingCompanyId", "dbo.TBShippingCompany");
            DropForeignKey("dbo.TBInvoice", "IssuerId", "dbo.TBIssuer");
            DropForeignKey("dbo.TBInvoice", "InvoiceTaxId", "dbo.TBInvoiceTax");
            DropForeignKey("dbo.TBInvoice", "AddresseeId", "dbo.TBAddressee");
            DropIndex("dbo.TBProduct", new[] { "Tax_Id" });
            DropIndex("dbo.TBSoldProduct", new[] { "Product_Id" });
            DropIndex("dbo.TBSoldProduct", new[] { "InvoiceId" });
            DropIndex("dbo.TBInvoice", new[] { "InvoiceTaxId" });
            DropIndex("dbo.TBInvoice", new[] { "AddresseeId" });
            DropIndex("dbo.TBInvoice", new[] { "ShippingCompanyId" });
            DropIndex("dbo.TBInvoice", new[] { "IssuerId" });
            DropTable("dbo.TBProductTax");
            DropTable("dbo.TBProduct");
            DropTable("dbo.TBSoldProduct");
            DropTable("dbo.TBShippingCompany");
            DropTable("dbo.TBIssuer");
            DropTable("dbo.TBInvoiceTax");
            DropTable("dbo.TBInvoice");
            DropTable("dbo.TBAddressee");
        }
    }
}
