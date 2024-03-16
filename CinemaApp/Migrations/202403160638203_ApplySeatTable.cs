namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplySeatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        SeatRow = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                        Invoice_DetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Invoice_Detail", t => t.Invoice_DetailId, cascadeDelete: true)
                .Index(t => t.Invoice_DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Invoice_DetailId", "dbo.Invoice_Detail");
            DropIndex("dbo.Seats", new[] { "Invoice_DetailId" });
            DropTable("dbo.Seats");
        }
    }
}
