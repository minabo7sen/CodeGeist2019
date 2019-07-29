namespace CodeGeist2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAndAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        BioGraphy = c.String(),
                        Rating = c.Double(nullable: false),
                        Verfied = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Rating = c.Double(nullable: false),
                        AgeLimit = c.Int(nullable: false),
                        Category = c.String(),
                        Views = c.Int(nullable: false),
                        Author_ID = c.Int(),
                        Account_ID = c.Int(),
                        Account_ID1 = c.Int(),
                        Account_ID2 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Author_ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID)
                .ForeignKey("dbo.Accounts", t => t.Account_ID1)
                .ForeignKey("dbo.Accounts", t => t.Account_ID2)
                .Index(t => t.Author_ID)
                .Index(t => t.Account_ID)
                .Index(t => t.Account_ID1)
                .Index(t => t.Account_ID2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Account_ID2", "dbo.Accounts");
            DropForeignKey("dbo.Books", "Account_ID1", "dbo.Accounts");
            DropForeignKey("dbo.Books", "Account_ID", "dbo.Accounts");
            DropForeignKey("dbo.Books", "Author_ID", "dbo.Accounts");
            DropIndex("dbo.Books", new[] { "Account_ID2" });
            DropIndex("dbo.Books", new[] { "Account_ID1" });
            DropIndex("dbo.Books", new[] { "Account_ID" });
            DropIndex("dbo.Books", new[] { "Author_ID" });
            DropTable("dbo.Books");
            DropTable("dbo.Accounts");
        }
    }
}
