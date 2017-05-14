namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renewedfieldtypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver_Id", c => c.Int());
            AddColumn("dbo.Messages", "Sender_Id", c => c.Int());
            AddColumn("dbo.UserRelations", "Who_Id", c => c.Int());
            AddColumn("dbo.UserRelations", "Whom_Id", c => c.Int());
            AddColumn("dbo.Users", "AppAuthId", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.UserRelations", "RelationType", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "About", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Photo", c => c.Binary(nullable: false));
            CreateIndex("dbo.Messages", "Receiver_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            CreateIndex("dbo.UserRelations", "Who_Id");
            CreateIndex("dbo.UserRelations", "Whom_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users", "Id");
            DropColumn("dbo.Messages", "SenderId");
            DropColumn("dbo.Messages", "ReceiverId");
            DropColumn("dbo.UserRelations", "Who");
            DropColumn("dbo.UserRelations", "Whom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRelations", "Whom", c => c.Int(nullable: false));
            AddColumn("dbo.UserRelations", "Who", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "ReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users");
            DropForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropIndex("dbo.UserRelations", new[] { "Whom_Id" });
            DropIndex("dbo.UserRelations", new[] { "Who_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            AlterColumn("dbo.Users", "Photo", c => c.Binary());
            AlterColumn("dbo.Users", "About", c => c.String());
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.UserRelations", "RelationType", c => c.Int());
            AlterColumn("dbo.Messages", "Body", c => c.String());
            DropColumn("dbo.Users", "AppAuthId");
            DropColumn("dbo.UserRelations", "Whom_Id");
            DropColumn("dbo.UserRelations", "Who_Id");
            DropColumn("dbo.Messages", "Sender_Id");
            DropColumn("dbo.Messages", "Receiver_Id");
        }
    }
}
