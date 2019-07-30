namespace CodeGeist2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
