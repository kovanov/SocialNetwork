namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class separateuserandprofile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "About");
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Photo", c => c.Binary(nullable: false));
            AddColumn("dbo.Users", "About", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
        }
    }
}
