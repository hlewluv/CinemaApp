namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        InvoiceDetail_Invoice_DetailId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Invoice_Detail", t => t.InvoiceDetail_Invoice_DetailId)
                .Index(t => t.InvoiceDetail_Invoice_DetailId);
            
            AddColumn("dbo.Invoice_Detail", "InvoiceID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoice_Detail", "InvoiceId");
            AddForeignKey("dbo.Invoice_Detail", "InvoiceId", "dbo.Invoices", "InvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice_Detail", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "InvoiceDetail_Invoice_DetailId", "dbo.Invoice_Detail");
            DropIndex("dbo.Invoices", new[] { "InvoiceDetail_Invoice_DetailId" });
            DropIndex("dbo.Invoice_Detail", new[] { "InvoiceId" });
            DropColumn("dbo.Invoice_Detail", "InvoiceID");
            DropTable("dbo.Invoices");
        }
    }
}
