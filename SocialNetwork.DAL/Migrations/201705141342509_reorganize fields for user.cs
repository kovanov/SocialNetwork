namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reorganizefieldsforuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "ProfileId" });
            AlterColumn("dbo.Users", "ProfileId", c => c.Int());
            CreateIndex("dbo.Users", "ProfileId");
            AddForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "ProfileId" });
            AlterColumn("dbo.Users", "ProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ProfileId");
            AddForeignKey("dbo.Users", "ProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
        }
    }
}
