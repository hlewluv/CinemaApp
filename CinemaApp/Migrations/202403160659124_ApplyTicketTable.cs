namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyTicketTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        SeatId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        InvoiceDetail_Invoice_DetailId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Invoice_Detail", t => t.InvoiceDetail_Invoice_DetailId)
                .Index(t => t.InvoiceDetail_Invoice_DetailId);
            
            AddColumn("dbo.Invoice_Detail", "TicketID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoice_Detail", "TicketId");
            AddForeignKey("dbo.Invoice_Detail", "TicketId", "dbo.Tickets", "TicketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice_Detail", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "InvoiceDetail_Invoice_DetailId", "dbo.Invoice_Detail");
            DropIndex("dbo.Tickets", new[] { "InvoiceDetail_Invoice_DetailId" });
            DropIndex("dbo.Invoice_Detail", new[] { "TicketId" });
            DropColumn("dbo.Invoice_Detail", "TicketID");
            DropTable("dbo.Tickets");
        }
    }
}
