namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somemigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Surname", c => c.String());
            AlterColumn("dbo.UserProfiles", "Sex", c => c.Int());
            AlterColumn("dbo.UserProfiles", "About", c => c.String());
            AlterColumn("dbo.UserProfiles", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Photo", c => c.Binary(nullable: false));
            AlterColumn("dbo.UserProfiles", "About", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfiles", "Sex", c => c.Int(nullable: false));
            AlterColumn("dbo.UserProfiles", "Surname", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
