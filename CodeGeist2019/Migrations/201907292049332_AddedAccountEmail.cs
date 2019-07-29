﻿namespace CodeGeist2019.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccountEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Email");
        }
    }
}
