namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilesmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users");
            DropForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.UserRelations", new[] { "Who_Id" });
            DropIndex("dbo.UserRelations", new[] { "Whom_Id" });
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        About = c.String(nullable: false),
                        Photo = c.Binary(nullable: false),
                        UserProfile_Id = c.Int(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.User_Id);
            
            AlterColumn("dbo.Messages", "Receiver_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "Sender_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRelations", "Who_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.UserRelations", "Whom_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "Receiver_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            CreateIndex("dbo.UserRelations", "Who_Id");
            CreateIndex("dbo.UserRelations", "Whom_Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users");
            DropForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.UserProfiles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserProfiles", "UserProfile_Id", "dbo.UserProfiles");
            DropIndex("dbo.UserRelations", new[] { "Whom_Id" });
            DropIndex("dbo.UserRelations", new[] { "Who_Id" });
            DropIndex("dbo.UserProfiles", new[] { "User_Id" });
            DropIndex("dbo.UserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            AlterColumn("dbo.UserRelations", "Whom_Id", c => c.Int());
            AlterColumn("dbo.UserRelations", "Who_Id", c => c.Int());
            AlterColumn("dbo.Messages", "Sender_Id", c => c.Int());
            AlterColumn("dbo.Messages", "Receiver_Id", c => c.Int());
            DropTable("dbo.UserProfiles");
            CreateIndex("dbo.UserRelations", "Whom_Id");
            CreateIndex("dbo.UserRelations", "Who_Id");
            CreateIndex("dbo.Messages", "Sender_Id");
            CreateIndex("dbo.Messages", "Receiver_Id");
            AddForeignKey("dbo.UserRelations", "Whom_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.UserRelations", "Who_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "Sender_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users", "Id");
        }
    }
}
