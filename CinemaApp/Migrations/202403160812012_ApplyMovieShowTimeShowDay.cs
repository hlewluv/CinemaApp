namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyMovieShowTimeShowDay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShowDetails",
                c => new
                    {
                        ShowDetailId = c.Int(nullable: false, identity: true),
                        MovieID = c.Int(nullable: false),
                        ShowDayID = c.Int(nullable: false),
                        ShowTimeID = c.Int(nullable: false),
                        InvoiceDetail_Invoice_DetailId = c.Int(),
                    })
                .PrimaryKey(t => t.ShowDetailId)
                .ForeignKey("dbo.Invoice_Detail", t => t.InvoiceDetail_Invoice_DetailId)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.ShowDays", t => t.ShowDayID, cascadeDelete: true)
                .ForeignKey("dbo.ShowTimes", t => t.ShowTimeID, cascadeDelete: true)
                .Index(t => t.MovieID)
                .Index(t => t.ShowDayID)
                .Index(t => t.ShowTimeID)
                .Index(t => t.InvoiceDetail_Invoice_DetailId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Duration = c.String(),
                        Director = c.String(),
                        RoomId = c.Int(nullable: false),
                        DayBegin = c.DateTime(nullable: false),
                        DayEnd = c.DateTime(nullable: false),
                        MovieName = c.String(),
                        Actor = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.ShowDays",
                c => new
                    {
                        ShowDayId = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShowDayId);
            
            CreateTable(
                "dbo.ShowTimes",
                c => new
                    {
                        ShowTimeId = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.ShowTimeId);
            
            AddColumn("dbo.Invoice_Detail", "ShowDetailID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoice_Detail", "ShowDetailId");
            AddForeignKey("dbo.Invoice_Detail", "ShowDetailId", "dbo.ShowDetails", "ShowDetailId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice_Detail", "ShowDetailId", "dbo.ShowDetails");
            DropForeignKey("dbo.ShowDetails", "ShowTimeID", "dbo.ShowTimes");
            DropForeignKey("dbo.ShowDetails", "ShowDayID", "dbo.ShowDays");
            DropForeignKey("dbo.ShowDetails", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.ShowDetails", "InvoiceDetail_Invoice_DetailId", "dbo.Invoice_Detail");
            DropIndex("dbo.ShowDetails", new[] { "InvoiceDetail_Invoice_DetailId" });
            DropIndex("dbo.ShowDetails", new[] { "ShowTimeID" });
            DropIndex("dbo.ShowDetails", new[] { "ShowDayID" });
            DropIndex("dbo.ShowDetails", new[] { "MovieID" });
            DropIndex("dbo.Invoice_Detail", new[] { "ShowDetailId" });
            DropColumn("dbo.Invoice_Detail", "ShowDetailID");
            DropTable("dbo.ShowTimes");
            DropTable("dbo.ShowDays");
            DropTable("dbo.Movies");
            DropTable("dbo.ShowDetails");
        }
    }
}
