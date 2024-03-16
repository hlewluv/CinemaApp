namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyChangeToInvoice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoice_Detail", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Invoice_Detail", new[] { "AccountId" });
            AddColumn("dbo.Invoices", "AccountId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Invoices", "AccountId");
            AddForeignKey("dbo.Invoices", "AccountId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Invoice_Detail", "AccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoice_Detail", "AccountId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Invoices", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Invoices", new[] { "AccountId" });
            DropColumn("dbo.Invoices", "AccountId");
            CreateIndex("dbo.Invoice_Detail", "AccountId");
            AddForeignKey("dbo.Invoice_Detail", "AccountId", "dbo.AspNetUsers", "Id");
        }
    }
}
