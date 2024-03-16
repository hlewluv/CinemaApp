namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyRoomTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        SeatQuantity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateIndex("dbo.Seats", "RoomID");
            AddForeignKey("dbo.Seats", "RoomID", "dbo.Rooms", "RoomID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Seats", new[] { "RoomID" });
            DropTable("dbo.Rooms");
        }
    }
}
