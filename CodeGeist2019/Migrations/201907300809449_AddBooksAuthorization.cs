namespace CodeGeist2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooksAuthorization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedBooks",
                c => new
                    {
                        AccountID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountID, t.BookID })
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasedBooks", "BookID", "dbo.Books");
            DropForeignKey("dbo.PurchasedBooks", "AccountID", "dbo.Accounts");
            DropIndex("dbo.PurchasedBooks", new[] { "BookID" });
            DropIndex("dbo.PurchasedBooks", new[] { "AccountID" });
            DropTable("dbo.PurchasedBooks");
        }
    }
}
