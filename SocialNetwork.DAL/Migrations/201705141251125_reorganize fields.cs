namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizefields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            RenameColumn(table: "dbo.Messages", name: "Receiver_Id", newName: "User_Id");
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "ReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "Profile_Id", c => c.Int());
            AlterColumn("dbo.Messages", "User_Id", c => c.Int());
            CreateIndex("dbo.Messages", "User_Id");
            CreateIndex("dbo.Users", "User_Id");
            CreateIndex("dbo.Users", "Profile_Id");
            AddForeignKey("dbo.Users", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Profile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Messages", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Messages", "Sender_Id");
            DropColumn("dbo.UserProfiles", "UserProfile_Id");
            DropColumn("dbo.UserProfiles", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "User_Id", c => c.Int(nullable: false));
            AddColumn("dbo.UserProfiles", "UserProfile_Id", c => c.Int());
            AddColumn("dbo.Messages", "Sender_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            AlterColumn("dbo.Messages", "User_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Profile_Id");
            DropColumn("dbo.Users", "User_Id");
            DropColumn("dbo.Messages", "ReceiverId");
            DropColumn("dbo.Messages", "SenderId");
            RenameColumn(table: "dbo.Messages", name: "User_Id", newName: "Receiver_Id");
            CreateIndex("dbo.UserProfiles", "User_Id");
            CreateIndex("dbo.UserProfiles", "UserProfile_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            CreateIndex("dbo.Messages", "Receiver_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProfiles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
