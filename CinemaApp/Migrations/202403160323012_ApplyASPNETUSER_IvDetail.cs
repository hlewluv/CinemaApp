namespace CinemaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyASPNETUSER_IvDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoice_Detail",
                c => new
                    {
                        Invoice_DetailId = c.Int(nullable: false, identity: true),
                        SeatId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AccountId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Invoice_DetailId)
                .ForeignKey("dbo.AspNetUsers", t => t.AccountId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice_Detail", "AccountId", "dbo.AspNetUsers");
            DropIndex("dbo.Invoice_Detail", new[] { "AccountId" });
            DropTable("dbo.Invoice_Detail");
        }
    }
}
