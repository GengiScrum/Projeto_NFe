namespace Projeto_NFe.Infra.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NFeContext_V4 : DbMigration
    {
        public override void Up()
        {
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
                        IssueDate = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        AccesKey = c.String(maxLength: 44, unicode: false),
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
            
            AddColumn("dbo.TBProduct", "InvoiceId", c => c.Int());
            AlterColumn("dbo.TBProduct", "Code", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.TBProduct", "Description", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBInvoice", "ShippingCompanyId", "dbo.TBShippingCompany");
            DropForeignKey("dbo.TBInvoice", "IssuerId", "dbo.TBIssuer");
            DropForeignKey("dbo.TBInvoice", "InvoiceTaxId", "dbo.TBInvoiceTax");
            DropForeignKey("dbo.TBInvoice", "AddresseeId", "dbo.TBAddressee");
            DropIndex("dbo.TBInvoice", new[] { "InvoiceTaxId" });
            DropIndex("dbo.TBInvoice", new[] { "AddresseeId" });
            DropIndex("dbo.TBInvoice", new[] { "ShippingCompanyId" });
            DropIndex("dbo.TBInvoice", new[] { "IssuerId" });
            AlterColumn("dbo.TBProduct", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.TBProduct", "Code", c => c.String(nullable: false));
            DropColumn("dbo.TBProduct", "InvoiceId");
            DropTable("dbo.TBInvoiceTax");
            DropTable("dbo.TBInvoice");
        }
    }
}
