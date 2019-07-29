namespace CodeGeist2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Books", "File_ID", c => c.Int());
            CreateIndex("dbo.Books", "File_ID");
            AddForeignKey("dbo.Books", "File_ID", "dbo.BookFiles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "File_ID", "dbo.BookFiles");
            DropIndex("dbo.Books", new[] { "File_ID" });
            DropColumn("dbo.Books", "File_ID");
            DropTable("dbo.BookFiles");
        }
    }
}
