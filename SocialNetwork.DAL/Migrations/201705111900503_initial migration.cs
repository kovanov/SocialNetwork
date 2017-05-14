namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Body = c.String(),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Who = c.Int(nullable: false),
                        Whom = c.Int(nullable: false),
                        RelationType = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        About = c.String(),
                        Photo = c.Binary(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRelations");
            DropTable("dbo.Messages");
        }
    }
}
