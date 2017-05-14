namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizefieldsagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Receiver_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "Sender_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "Receiver_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Users", "Id", cascadeDelete: false);
            DropColumn("dbo.Messages", "SenderId");
            DropColumn("dbo.Messages", "ReceiverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReceiverId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SenderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropColumn("dbo.Messages", "Sender_Id");
            DropColumn("dbo.Messages", "Receiver_Id");
        }
    }
}
